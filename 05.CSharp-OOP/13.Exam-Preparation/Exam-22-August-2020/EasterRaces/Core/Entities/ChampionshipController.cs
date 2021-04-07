using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository driversRepository;
        private CarRepository carsRepository;
        private RaceRepository racesRepository;

        public ChampionshipController()
        {
            driversRepository = new DriverRepository();
            carsRepository = new CarRepository();
            racesRepository = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            if (driversRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            driversRepository.Add(new Driver(driverName));

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (carsRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            carsRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (racesRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            racesRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (racesRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (driversRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            racesRepository.GetByName(raceName).AddDriver(driversRepository.GetByName(driverName));

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (driversRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (carsRepository.GetByName(carModel) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            IDriver currentDriver = driversRepository.GetByName(driverName);
            ICar currentCar = carsRepository.GetByName(carModel);

            currentDriver.AddCar(currentCar);

            //if (currentDriver.Car != null)
            //{
            //    string model = currentDriver.Car.Model;
            //    currentDriver.AddCar(carsRepository.GetByName(carModel));
            //    return string.Format(OutputMessages.CarReplaced, driverName, carModel);
            //}


            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string StartRace(string raceName)
        {
            if (racesRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IRace currentRace = racesRepository.GetByName(raceName);

            if (currentRace.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var sortedDrivers = currentRace
                .Drivers
                .OrderByDescending(d => d.Car.CalculateRacePoints(currentRace.Laps))
                .ToList();

            racesRepository.Remove(currentRace);

            return Qualification(sortedDrivers, currentRace.Name);
        }

        private string Qualification(List<IDriver> drivers, string raceName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, drivers[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, drivers[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, drivers[2].Name, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}