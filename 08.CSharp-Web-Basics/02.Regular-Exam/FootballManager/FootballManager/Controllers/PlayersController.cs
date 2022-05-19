namespace FootballManager.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using MyWebServer.Controllers;
    using MyWebServer.Results;
    using Services.Contracts;
    using ViewModels.Players;

    public class PlayersController : Controller
    {
        private readonly IValidationService validationService;
        private readonly IPlayersService playersService;

        public PlayersController(
            IValidationService validationService,
            IPlayersService playersService)
        {
            this.validationService = validationService;
            this.playersService = playersService;
        }

        [Authorize]
        public ActionResult All() 
            => View(this.playersService.All().ToList());

        [Authorize]
        public ActionResult Add()
            => View();

        [HttpPost]
        [Authorize]
        public ActionResult Add(PlayerFormModel formModel)
        {
            var (validationResult, errors) = this.validationService
                .IsModelValid(formModel);

            var isPositionValid = this.validationService
                .IsPositionValid(formModel.Position);

            if (!validationResult ||
                !isPositionValid)
            {
                var allErrors = errors == null
                    ? new List<string>()
                    : errors.ToList();

                if (!isPositionValid)
                {
                    allErrors.Add("Position is not valid!");
                }

                return Error(allErrors);
            }

            var isSucceed = this.playersService
                .TryAdd(
                    this.User.Id,
                    formModel.FullName,
                    formModel.ImageUrl,
                    formModel.Position,
                    (byte) formModel.Speed,
                    (byte) formModel.Endurance,
                    formModel.Description);

            if (!isSucceed)
            {
                return Error("Player already exist!");
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public ActionResult AddToCollection(int playerId)
        {
            if (!this.playersService.IsPlayerExist(playerId))
            {
                return Error("Player does not exist!");
            }

            var isSucceed = this.playersService
                .AddPlayerToUser(playerId, this.User.Id);

            if (!isSucceed)
            {
                return Error("Player is already in collection of players.");
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public ActionResult Collection()
            => View(this.playersService.All(this.User.Id));

        [Authorize]
        public ActionResult RemoveFromCollection(int playerId)
        {
            if (!this.playersService.IsPlayerExist(playerId))
            {
                return Error("Player does not exist!");
            }

            bool isSucceed = this.playersService
                .Remove(playerId, this.User.Id);

            if (!isSucceed)
            {
                return Error("Player is not in collection!");
            }

            return Redirect("/Players/Collection");
        }
    }
}
