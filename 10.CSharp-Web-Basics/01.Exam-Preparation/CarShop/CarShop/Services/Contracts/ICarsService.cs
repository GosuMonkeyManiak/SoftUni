namespace CarShop.Services.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface ICarsService
    {
        bool Add(
            string userId,
            string model,
            int year,
            string imageUrl,
            string plateNumber);

        IEnumerable<CarDto> All();

        IEnumerable<CarDto> All(string userId);

        bool IsCarExist(string carId);

        CarListingIssuesDto AllIssuesByCarId(string carId, bool user);
    }
}
