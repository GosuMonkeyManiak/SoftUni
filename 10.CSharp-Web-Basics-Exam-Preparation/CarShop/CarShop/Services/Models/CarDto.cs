namespace CarShop.Services.Models
{
    public class CarDto
    {
        public string Id { get; init; }

        public string Model { get; init; }
        
        public string PictureUrl { get; init; }

        public string PlateNumber { get; init; }

        public int FixedIssues { get; init; }

        public int RemainIssues { get; init; }
    }
}
