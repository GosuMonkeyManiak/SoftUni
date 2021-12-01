namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            List<ExportPrisonerDto> prisoners = new List<ExportPrisonerDto>();

            foreach (var id in ids)
            {
                var prisoner = context.Prisoners
                    .Include(p => p.Cell)
                    .Include(p => p.PrisonerOfficers)
                    .ThenInclude(op => op.Officer)
                    .ThenInclude(o => o.Department)
                    .ToList()
                    .Where(p => p.Id == id)
                    .Select(p => new ExportPrisonerDto()
                    {
                        Id = p.Id,
                        Name = p.FullName,
                        CellNumber = p.Cell.CellNumber,
                        Officers = p.PrisonerOfficers
                            .Select(op => new ExportPrisonerOfficerDto()
                            {
                                OfficerName = op.Officer.FullName,
                                Department = op.Officer.Department.Name
                            })
                            .OrderBy(o => o.OfficerName)
                            .ToArray(),
                        TotalOfficerSalary = Math.Round(p.PrisonerOfficers
                            .Sum(op => op.Officer.Salary), 2)
                    })
                    .FirstOrDefault();

                prisoners.Add(prisoner);
            }

            prisoners = prisoners
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToList();

            return JsonConvert.SerializeObject(prisoners, Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Prisoners");

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportPrisonerXmlDto>), xmlRoot);

            StringBuilder result = new StringBuilder();

            List<ExportPrisonerXmlDto> prisoners = new List<ExportPrisonerXmlDto>();

            string[] names = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var name in names)
            {
                var prisoner = context.Prisoners
                    .Include(p => p.Mails)
                    .ToList()
                    .Where(p => p.FullName == name)
                    .Select(p => new ExportPrisonerXmlDto()
                    {
                        Id = p.Id,
                        Name = p.FullName,
                        IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                        Messages = p.Mails
                            .Select(m => new ExportPrisonerMessageDto()
                            {
                                Description = new string(m.Description.Reverse().ToArray()) 
                            })
                            .ToArray()
                    })
                    .FirstOrDefault();

                prisoners.Add(prisoner);
            }

            prisoners = prisoners
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToList();

            using (StringWriter stringWriter = new StringWriter(result))
            {
                xmlSerializer.Serialize(stringWriter, prisoners, xmlNamespaces);
            }

            return result.ToString().TrimEnd();
        }
    }
}