namespace CarShop.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Data.Model;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CarsService : ICarsService
    {
        private readonly CarShopDbContext dbContext;

        public CarsService(CarShopDbContext dbContext)
            => this.dbContext = dbContext;

        public bool Add(
            string userId,
            string model, 
            int year, 
            string imageUrl, 
            string plateNumber)
        {
            if (IsCarExistByPlateNumber(plateNumber))
            {
                return false;
            }

            var car = new Car()
            {
                Model = model,
                Year = year,
                PictureUrl = imageUrl,
                PlateNumber = plateNumber,
                OwnerId = userId
            };

            this.dbContext
                .Cars
                .Add(car);

            this.dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<CarDto> All()
            => this.dbContext
                .Cars
                .Include(c => c.Issues)
                .Select(c => new CarDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    PictureUrl = c.PictureUrl,
                    PlateNumber = c.PlateNumber,
                    FixedIssues = c.Issues
                        .Count(i => i.IsFixed),
                    RemainIssues = c.Issues
                        .Count(i => i.IsFixed == false)
                })
                .Where(c => c.RemainIssues >= 1)
                .ToList();

        public IEnumerable<CarDto> All(string userId)
            => this.dbContext
                .Cars
                .Include(c => c.Issues)
                .Where(c => c.OwnerId == userId)
                .Select(c => new CarDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    PictureUrl = c.PictureUrl,
                    PlateNumber = c.PlateNumber,
                    FixedIssues = c.Issues
                        .Count(i => i.IsFixed),
                    RemainIssues = c.Issues
                        .Count(i => i.IsFixed == false)
                })
                .ToList();

        public bool IsCarExist(string carId)
            => this.dbContext
                .Cars
                .FirstOrDefault(c => c.Id == carId) != null;

        public CarListingIssuesDto AllIssuesByCarId(string carId, bool user)
        {
            var carWithIssues = this.dbContext
                .Cars
                .Include(c => c.Issues)
                .Include(c => c.Owner)
                .FirstOrDefault(c => c.Id == carId);

            var result = new CarListingIssuesDto()
            {
                Id = carId,
                Model = carWithIssues.Model,
                IsMechanic = user,
                Issues = carWithIssues.Issues
                    .Select(i => new IssueDto()
                    {
                        Id = i.Id,
                        Description = i.Description,
                        IsFixed = i.IsFixed
                    })
            };

            return result;
        }

        private bool IsCarExistByPlateNumber(string plateNumber)
            => this.dbContext
                .Cars
                .FirstOrDefault(c => c.PlateNumber == plateNumber) != null;
    }
}
