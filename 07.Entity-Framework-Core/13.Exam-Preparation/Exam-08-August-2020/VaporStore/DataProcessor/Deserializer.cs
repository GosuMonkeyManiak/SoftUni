using Newtonsoft.Json;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Import;
using VaporStore.DataProcessor.Import;

namespace VaporStore.DataProcessor
{
    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            List<Genre> genres = new List<Genre>();
            List<Developer> developers = new List<Developer>();
            List<Tag> tags = new List<Tag>();
            List<Game> games = new List<Game>();

            StringBuilder result = new StringBuilder();
            string errorMessage = "Invalid Data";


            foreach (var gameDto in gamesDto)
            {
                if (!IsValid(gameDto))
                {
                    result.AppendLine(errorMessage);
					continue;
                }

                bool isValidReleaseDate = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

                if (!isValidReleaseDate)
                {
                    result.AppendLine(errorMessage);
                    continue;
                }

                Game currentGame = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate
                };

                Developer dev = developers.FirstOrDefault(d => d.Name == gameDto.Developer);

                if (dev == null)
                {
                    dev = new Developer() { Name = gameDto.Developer };
                    developers.Add(dev);
                }

                currentGame.Developer = dev;

                Genre genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);

                if (genre == null)
                {
                    genre = new Genre() { Name = gameDto.Genre };
                    genres.Add(genre);
                }

                currentGame.Genre = genre;
                currentGame.GameTags = new List<GameTag>();

                foreach (var tagDto in gameDto.Tags)
                {
                    Tag tag = tags.FirstOrDefault(t => t.Name == tagDto);

                    if (tag == null)
                    {
                        tag = new Tag() { Name = tagDto };
                        tags.Add(tag);
                    }

                    currentGame.GameTags.Add(new GameTag(){Tag = tag});
                }

                games.Add(currentGame);

                result.AppendLine($"Added {currentGame.Name} ({currentGame.Genre.Name}) with {currentGame.GameTags.Count} tags");
            }


            context.Games.AddRange(games);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            string errorMessage = "Invalid Data";

            bool isCardValid = true;

            List<User> users = new List<User>();

            foreach (var userDto in usersDto)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        sb.AppendLine(errorMessage);
                        isCardValid = false;
                        break;
                    }

                    bool isTypeValid = Enum.TryParse(typeof(CardType), cardDto.Type, out object cardType);

                    if (!isTypeValid)
                    {
                        sb.AppendLine(errorMessage);
                        isCardValid = false;
                        break;
                    }
                }

                if (!isCardValid)
                {
                    isCardValid = true;
                    continue;
                }

                User user = new User()
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Age = userDto.Age,
                    Email = userDto.Email,
                };

                user.Cards = userDto.Cards
                    .Select(c => new Card()
                    {
                        Number = c.Number,
                        Cvc = c.CVC,
                        Type = Enum.Parse<CardType>(c.Type),
                        User = user
                    })
                    .ToList();

                users.Add(user);

                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Purchases");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPurchaseDto[]), xmlRoot);

            List<Card> cards = context.Cards
                    .Include(c => c.User)
                    .ToList();
            List<Game> games = context.Games.ToList();

            StringBuilder result = new StringBuilder();
            string errorMessage = "Invalid Data";

            ImportPurchaseDto[] purchasesDto = null;

            using (StringReader stringReader = new StringReader(xmlString))
            {
                purchasesDto = (ImportPurchaseDto[]) serializer.Deserialize(stringReader);
            }

            List<Purchase> purchases = new List<Purchase>();

            foreach (var purchaseDto in purchasesDto)
            {
                if (!IsValid(purchaseDto))
                {
                    result.AppendLine(errorMessage);
                    continue;
                }

                bool isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                if (!isDateValid)
                {
                    result.AppendLine(errorMessage);
                    continue;
                }

                bool isTypeValid = Enum.TryParse(typeof(PurchaseType), purchaseDto.Type, out object purchaseType);

                if (!isTypeValid)
                {
                    result.AppendLine(errorMessage);
                    continue;
                }

                Purchase purchase = new Purchase()
                {
                    Type = Enum.Parse<PurchaseType>(purchaseDto.Type),
                    ProductKey = purchaseDto.Key,
                    Date = date,
                    Card = cards.Find(c => c.Number == purchaseDto.Card),
                    Game = games.Find(g => g.Name == purchaseDto.Title)
                };
                
                purchases.Add(purchase);

                result.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}