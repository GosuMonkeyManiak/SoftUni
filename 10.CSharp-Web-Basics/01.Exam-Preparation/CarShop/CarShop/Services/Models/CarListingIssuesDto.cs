namespace CarShop.Services.Models
{
    using System.Collections.Generic;

    public class CarListingIssuesDto
    {
        public string Id { get; init; }

        public string Model { get; init; }

        public bool IsMechanic { get; init; }

        public IEnumerable<IssueDto> Issues { get; init; }
    }
}
