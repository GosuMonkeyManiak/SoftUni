namespace VaporStore.DataProcessor.Dto.Export
{
    public class ExportGenreDto
    {
        public int Id { get; set; }

        public string Genre { get; set; }

        public ExportGenreGameDto[] Games { get; set; }

        public int TotalPlayers { get; set; }
    }
}
