namespace SharedTrip.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Contracts;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using SharedTrip.Models;

    using static Data.Common.DataConstrains;

    public class TripService : ITripService
    {
        private readonly SharedTripDbContext dbContext;

        public TripService(SharedTripDbContext dbContext)
            => this.dbContext = dbContext;

        public IEnumerable<TripDto> All()
            => this.dbContext
                .Trips
                .Select(t => new TripDto()
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString(DateTimeFormat),
                    Seats = Math.Abs(t.Seats - t.UserTrips.Count),
                })
                .ToList();

        public bool Add(
            string startPoint,
            string endPoint,
            string departureTime,
            string imagePath,
            int seats,
            string description)
        {
            if (IsExist(
                    startPoint,
                    endPoint,
                    departureTime,
                    seats))
            {
                return false;
            }

            var trip = new Trip()
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                DepartureTime = ParseDateTime(departureTime),
                Seats = seats,
                Description = description,
                ImagePath = imagePath
            };

            this.dbContext
                .Trips
                .Add(trip);

            this.dbContext
                .SaveChanges();

            return true;
        }

        public bool AddTripToUser(string tripId, string userId)
        {
            var trip = this.dbContext
                .Trips
                .Include(t => t.UserTrips)
                .FirstOrDefault(t => t.Id == tripId);

            if (trip.Seats == trip.UserTrips.Count)
            {
                return false;
            }

            var user = this.dbContext
                .Users
                .Include(u => u.UserTrips)
                .SingleOrDefault(u => u.Id == userId);

            var isUserInTrip = user
                .UserTrips
                .Any(ut => ut.TripId == tripId);

            if (isUserInTrip)
            {
                return false;
            }

            user
                .UserTrips
                .Add(new UserTrip()
                {
                    TripId = tripId
                });

            this.dbContext.SaveChanges();

            return true;
        }

        public TripDetailModel GetById(string tripId)
            => this.dbContext
                .Trips
                .Where(t => t.Id == tripId)
                .Select(t => new TripDetailModel()
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString(),
                    Description = t.Description,
                    ImagePath = t.ImagePath,
                    Seats = t.Seats
                })
                .FirstOrDefault();

        public bool IsTripExist(string tripId)
            => this.dbContext
                .Trips
                .Any(t => t.Id == tripId);

        private bool IsExist(
            string startPoint,
            string endPoint,
            string departureTime,
            int seats)
        {
            var parsedDateTime = ParseDateTime(departureTime);

            var trip = this.dbContext
                .Trips
                .FirstOrDefault(t =>
                    t.StartPoint == startPoint &&
                    t.EndPoint == endPoint &&
                    t.DepartureTime == parsedDateTime &&
                    t.Seats == seats);

            if (trip == null)
            {
                return false;
            }

            return true;
        }

        private DateTime ParseDateTime(string dateTime)
            => DateTime.ParseExact(
                dateTime,
                DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None);
    }
}
