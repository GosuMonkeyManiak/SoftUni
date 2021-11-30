using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Export;

namespace VaporStore.DataProcessor
{
	using System;
	using Data;

	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			List<ExportGenreDto> genresDto = new List<ExportGenreDto>();

            foreach (var genreName in genreNames)
            {
                var genreDto = context.Genres
                    .Include(g => g.Games)
                    .ThenInclude(g => g.Purchases)
                    .Include(g => g.Games)
                    .ThenInclude(d => d.Developer)
                    .Include(g => g.Games)
                    .ThenInclude(gt => gt.GameTags)
                    .ThenInclude(t => t.Tag)
                    .ToList()
                    .Where(g => g.Name == genreName)
                    .Where(g => g.Games.Any(p => p.Purchases.Any()))
                    .Select(g => new ExportGenreDto()
                    {
                        Id = g.Id,
                        Genre = g.Name,
                        Games = g.Games
                            .Where(g => g.Purchases.Any())
                            .Select(x => new ExportGenreGameDto()
                            {
                                Id = x.Id,
                                Title = x.Name,
                                Developer = x.Developer.Name,
                                Tags = string.Join(", ", x.GameTags.Select(gt => gt.Tag.Name)),
                                Players = x.Purchases.Count
                            })
                            .OrderByDescending(e => e.Players)
                            .ThenBy(e => e.Id)
                            .ToArray(),
                        TotalPlayers = g.Games.Sum(p => p.Purchases.Count)
                    })
                    .ToList();

                genresDto.AddRange(genreDto);
            }

            genresDto = genresDto
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToList();

            return JsonConvert.SerializeObject(genresDto, Formatting.Indented);
        }

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var users = context.Users
                .Include(u => u.Cards)
                .ThenInclude(c => c.Purchases)
                .ThenInclude(p => p.Game)
                .ThenInclude(p => p.Genre)
                .ToList()
                .Where(u => u.Cards.Any(c => c.Purchases.Any()))
                .Select(u => new ExportUserDto()
                {
                    Username = u.Username,
                    Purchases = u.Cards
                        .SelectMany(c => c.Purchases)
                        .Where(p => p.Type == Enum.Parse<PurchaseType>(storeType))
                        .OrderBy(p => p.Date)
                        .Select(p => new ExportUserPurchaseDto()
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm"),
                            Game = new ExportUserPurchaseGameDto()
                            {
                                Genre = p.Game.Genre.Name,
                                Price = $"{p.Game.Price / 1.000000000000000000000000000000000m}",
                                Title = p.Game.Name
                            }
                        })
                        .ToArray(),
                    TotalSpent = u.Cards
                        .SelectMany(c => c.Purchases)
                        .Where(p => p.Type == Enum.Parse<PurchaseType>(storeType))
                        .Sum(p => p.Game.Price) / 1.000000000000000000000000000000000m
                })
                .Where(u => u.Purchases.Any())
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToList();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportUserDto>), xmlRoot);

            StringBuilder result = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(result))
            {
                xmlSerializer.Serialize(stringWriter, users, xmlNamespaces);
            }

            return result.ToString().TrimEnd();
        }
	}
}