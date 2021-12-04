namespace Theatre.DataProcessor
{
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPlayDto[]), xmlRoot);

            StringBuilder result = new StringBuilder();

            ImportPlayDto[] playsDto = null;

            using (StringReader stringReader = new StringReader(xmlString))
            {
                playsDto = (ImportPlayDto[]) serializer.Deserialize(stringReader);
            }

            List<Play> plays = new List<Play>();

            foreach (var playDto in playsDto)
            {
                if (!IsValid(playDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                bool isGenreValid = Enum.TryParse(typeof(Genre), playDto.Genre, out object genre);

                if (!isGenreValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan duration = TimeSpan.Parse(playDto.Duration, CultureInfo.InvariantCulture);

                if (duration.Hours < 1)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                float rating = float.Parse(playDto.Rating);

                if (rating < 0.00f || rating > 10.00f)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Play validPlay = new Play()
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = rating,
                    Genre = Enum.Parse<Genre>(playDto.Genre),
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                plays.Add(validPlay);

                result.AppendLine(string.Format(SuccessfulImportPlay, validPlay.Title, validPlay.Genre.ToString(),
                    validPlay.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCastDto[]), xmlRoot);

            StringBuilder result = new StringBuilder();

            ImportCastDto[] castsDto = null;
            List<int> playsId = context.Plays.Select(p => p.Id).ToList();

            using (StringReader stringReader = new StringReader(xmlString))
            {
                castsDto = (ImportCastDto[]) serializer.Deserialize(stringReader);
            }

            List<Cast> casts = new List<Cast>();

            foreach (var castDto in castsDto)
            {
                if (!IsValid(castDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                if (!playsId.Contains(castDto.PlayId))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Cast validCast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                casts.Add(validCast);

                result.AppendLine(string.Format(SuccessfulImportActor, validCast.FullName,
                    validCast.IsMainCharacter == true ? "main" : "lesser"));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            ImportTheatreDto[] theatresDto = JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);

            List<int> playsId = context.Plays.Select(p => p.Id).ToList();

            StringBuilder result = new StringBuilder();

            bool isPlayValid = true;

            List<Theatre> theatres = new List<Theatre>();
            List<Ticket> tickets = new List<Ticket>();

            foreach (var theatreDto in theatresDto)
            {
                if (!IsValid(theatreDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                if (theatreDto.NumberOfHalls < 1 || theatreDto.NumberOfHalls > 10)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                List<ImportTheatreTicketDto> validTickets = new List<ImportTheatreTicketDto>();

                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!playsId.Contains(ticketDto.PlayId))
                    {
                        result.AppendLine(ErrorMessage);
                        isPlayValid = false;
                        break;
                    }

                    if (ticketDto.Price < 1m || ticketDto.Price > 100m)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (ticketDto.RowNumber < 1 || ticketDto.RowNumber > 10)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    validTickets.Add(ticketDto);
                }

                if (!isPlayValid)
                {
                    isPlayValid = true;
                    continue;
                }

                Theatre validTheatre = new Theatre()
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director,
                };

                List<Ticket> currentTickets = validTickets
                    .Select(t => new Ticket()
                    {
                        Price = t.Price,
                        RowNumber = t.RowNumber,
                        PlayId = t.PlayId,
                        Theatre = validTheatre
                    })
                    .ToList();

                tickets.AddRange(currentTickets);
                theatres.Add(validTheatre);

                result.AppendLine(string.Format(SuccessfulImportTheatre, theatreDto.Name,
                    validTickets.Count));
            }
            
            context.Tickets.AddRange(tickets);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
