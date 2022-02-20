namespace SharedTrip.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using MyWebServer.Controllers;
    using MyWebServer.Results;
    using Services.Contracts;

    using static Data.Common.DataConstrains;

    public class TripsController : Controller
    {
        private readonly ITripService tripService;
        private readonly IValidationService validationService;

        public TripsController(
            ITripService tripService,
            IValidationService validationService)
        {
            this.tripService = tripService;
            this.validationService = validationService;
        }

        [Authorize]
        public ActionResult All()
            => View(this.tripService.All());

        [Authorize]
        public ActionResult Add()
            => View();

        [HttpPost]
        [Authorize]
        public ActionResult Add(TripFormModel formModel)
        {
            var (validationResult, errors) = this.validationService
                .IsModelValid(formModel);

            var dateTimeValidationResult = this.validationService
                .IsDateTimeValid(formModel.DepartureTime, DateTimeFormat);

            if (!validationResult || 
                !dateTimeValidationResult)
            {
                var allError = errors != null ? errors.ToList() : new List<string>();

                if (!dateTimeValidationResult)
                {
                    allError.Add("Incorrect Departure time format.");
                }

                return Error(allError);
            }

            bool isSucceed = this.tripService
                .Add(
                    formModel.StartPoint,
                    formModel.EndPoint,
                    formModel.DepartureTime,
                    formModel.ImagePath,
                    formModel.Seats,
                    formModel.Description);

            if (!isSucceed)
            {
                return Error("User already exists!");
            }

            return Redirect("/Trips/All");
        }

        [Authorize]
        public ActionResult Details(string tripId)
        {
            if (!this.tripService.IsTripExist(tripId))
            {
                return Error("Trip doesn't exist!");
            }

            var trip = this.tripService.GetById(tripId);

            return View(trip);
        }
        
        [Authorize]
        public ActionResult AddUserToTrip(string tripId)
        {
            if (!this.tripService.IsTripExist(tripId))
            {
                return Error("Trip doesn't exist!");
            }

            bool isSucceed = this.tripService.AddTripToUser(tripId, this.User.Id);

            if (!isSucceed)
            {
               return Redirect($"/Trips/Details?tripId={tripId}");
            }

            return Redirect("/Trips/All");
        }
    }
}
