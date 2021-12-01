namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            bool isCellsValid = true;

            StringBuilder result = new StringBuilder();
            string errorMessage = "Invalid Data";

            List<Department> departments = new List<Department>();

            foreach (var departmentDto in departmentsDto)
            {
                if (!IsValid(departmentDto))
                {
                    result.AppendLine(errorMessage);
                    continue;
                }

                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        result.AppendLine(errorMessage);
                        isCellsValid = false;
                        break;
                    }
                }

                if (!isCellsValid)
                {
                    isCellsValid = true;
                    continue;
                }

                Department validDepartment = new Department()
                {
                    Name = departmentDto.Name,
                    Cells = departmentDto.Cells
                        .Select(c => new Cell()
                        {
                            CellNumber = c.CellNumber,
                            HasWindow = c.HasWindow
                        })
                        .ToList()
                };

                departments.Add(validDepartment);

                result.AppendLine($"Imported {validDepartment.Name} with {validDepartment.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            List<int> cells = context.Cells.Select(c => c.Id).ToList();

            bool isMailsValid = true;

            StringBuilder result = new StringBuilder();
            string errorMessage = "Invalid Data";

            List<Prisoner> prisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonersDto)
            {
                if (!IsValid(prisonerDto))
                {
                    result.AppendLine(errorMessage);
                    continue;
                }

                bool isValidIncarcerationDate = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime incarcerationDate);

                if (!isValidIncarcerationDate)
                {
                    result.AppendLine(errorMessage);
                    continue;
                }

                DateTime? releaseDate = null;

                if (prisonerDto.ReleaseDate != null)
                {
                    bool isValidReleaseDate = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDateFromParse);

                    if (!isValidReleaseDate)
                    {
                        result.AppendLine(errorMessage);
                        continue;
                    }

                    releaseDate = releaseDateFromParse;
                }

                if (prisonerDto.Bail != null && prisonerDto.Bail < 0)
                {
                    result.AppendLine(errorMessage);
                    continue;
                }

                
                //if (!cells.Contains(prisonerDto.CellId))
                //{
                //    result.AppendLine(errorMessage);
                //    continue;
                //}
                

                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        result.AppendLine(errorMessage);
                        isMailsValid = false;
                        break;
                    }
                }

                if (!isMailsValid)
                {
                    isMailsValid = true;
                    break;
                }

                Prisoner validPrisoner = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                    Mails = prisonerDto.Mails
                        .Select(m => new Mail()
                        {
                            Description = m.Description,
                            Sender = m.Sender,
                            Address = m.Address
                        })
                        .ToList()
                };

                prisoners.Add(validPrisoner);

                result.AppendLine($"Imported {validPrisoner.FullName} {validPrisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Officers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), xmlRoot);

            ImportOfficerDto[] officersDto = null;

            using (StringReader stringReader = new StringReader(xmlString))
            {
                officersDto = (ImportOfficerDto[])xmlSerializer.Deserialize(stringReader);
            }

            List<int> departmentIds = context.Departments.Select(d => d.Id).ToList();

            StringBuilder result = new StringBuilder();
            string errorMessage = "Invalid Data";

            List<Officer> officers = new List<Officer>();

            foreach (var officerDto in officersDto)
            {
                if (!IsValid(officerDto))
                {
                    result.AppendLine(errorMessage);
                    continue;
                }

                bool isValidPosition = Enum.TryParse(typeof(Position), officerDto.Position, out object position);

                if (!isValidPosition)
                {
                    result.AppendLine(errorMessage);
                    continue;
                }

                bool isValidWeapon = Enum.TryParse(typeof(Weapon), officerDto.Weapon, out object weapon);

                if (!isValidWeapon)
                {
                    result.AppendLine(errorMessage);
                    continue;
                }

                //if (!departmentIds.Contains(officerDto.DepartmentId))
                //{
                //    result.AppendLine(errorMessage);
                //    continue;
                //}

                if (officerDto.Salary < 0)
                {
                    result.AppendLine(errorMessage);
                    continue;
                }

                Officer validOfficer = new Officer()
                {
                    FullName = officerDto.FullName,
                    Salary = officerDto.Salary,
                    Position = Enum.Parse<Position>(officerDto.Position),
                    Weapon = Enum.Parse<Weapon>(officerDto.Weapon),
                    DepartmentId = officerDto.DepartmentId,
                    OfficerPrisoners = officerDto.Prisoners
                        .Select(p => new OfficerPrisoner()
                        {
                            PrisonerId = p.Id
                        })
                        .ToList(),
                };

                officers.Add(validOfficer);

                result.AppendLine($"Imported {validOfficer.FullName} ({validOfficer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}