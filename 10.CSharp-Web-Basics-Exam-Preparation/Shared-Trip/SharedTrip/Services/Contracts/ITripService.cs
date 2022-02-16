namespace SharedTrip.Services.Contracts
{
    using System.Collections.Generic;
    using Models;
    using SharedTrip.Models;

    public interface ITripService
    {
        IEnumerable<TripDto> All();

        bool Add(string startPoint,
            string endPoint,
            string departureTime,
            string imagePath,
            int seats,
            string description);

        bool AddTripToUser(string tripId, string userId);

        TripDetailModel GetById(string tripId);

        bool IsTripExist(string tripId);
    }
}
