using System;
using MusicHub.Data;
using MusicHub.Data.Models;
using System.Linq;
using System.Text;
using MusicHub.Initializer;

namespace MusicHub
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsByProducer = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    AlbumReleaseDate = a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    AlbumSong = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price,
                            WriterName = s.Writer.Name
                        }),
                    AlbumPrice = a.Price
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var albums in albumsByProducer.OrderByDescending(a => a.AlbumPrice))
            {
                sb.Append($"-AlbumName: {albums.AlbumName}\r\n");
                sb.Append($"-ReleaseDate: {albums.AlbumReleaseDate:MM/dd/yyyy}\r\n");
                sb.Append($"-ProducerName: {albums.ProducerName}\r\n");
                sb.Append("-Songs:\r\n");

                int count = 1;

                foreach (var song in albums.AlbumSong
                                                    .OrderByDescending(s => s.SongName)
                                                    .ThenBy(s => s.WriterName))
                {
                    sb.Append($"---#{count}\r\n");
                    sb.Append($"---SongName: {song.SongName}\r\n");
                    sb.Append($"---Price: {song.SongPrice:f2}\r\n");
                    sb.Append($"---Writer: {song.WriterName}\r\n");

                    count++;
                }

                sb.Append($"-AlbumPrice: {albums.AlbumPrice:f2}\r\n");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songAboveDuration = context.Songs
                .Where(s => s.Duration > new TimeSpan(0, 0, 0, duration))
                .Select(s => new
                {
                    SongName = s.Name,
                    PerformerFullName = s.SongPerformers.FirstOrDefault() == null ? "" : s.SongPerformers.FirstOrDefault().Performer.FirstName + " " + s.SongPerformers.FirstOrDefault().Performer.LastName,
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PerformerFullName)
                .ToList();
                

            StringBuilder sb = new StringBuilder();
            int count = 1;

            foreach (var song in songAboveDuration)
            {

                sb.Append($"-Song #{count}\r\n");
                sb.Append($"---SongName: {song.SongName}\r\n");
                sb.Append($"---Writer: {song.WriterName}\r\n");
                sb.Append($"---Performer: {song.PerformerFullName}\r\n");
                sb.Append($"---AlbumProducer: {song.AlbumProducer}\r\n");
                sb.Append($"---Duration: {song.Duration:c}\r\n");

                count++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
