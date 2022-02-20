namespace SharedTrip.Models
{
    public class TripDetailModel
    {
        public string Id { get; init; }

        public string StartPoint { get; init; }

        public string EndPoint { get; init; }

        public string DepartureTime { get; init; }
    
        public string ImagePath { get; init; }
     
        public int Seats { get; init; }

        public string Description { get; init; }
    }
}
