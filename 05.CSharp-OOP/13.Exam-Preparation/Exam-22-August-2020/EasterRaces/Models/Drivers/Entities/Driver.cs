using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private int numberOfWins;
        private bool canParticipate;

        public Driver(string name)
        {
            Name = name;
            CanParticipate = false;
            NumberOfWins = 0;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }

                name = value;
            }
        }

        public ICar Car
        {
            get => car;
            private set => car = value;
        }

        public int NumberOfWins
        {
            get => numberOfWins;
            private set => numberOfWins = value;
        }

        public bool CanParticipate
        {
            get
            {
                if (car != null)
                {
                    return true;
                }

                return false;
            }
            private set => canParticipate = value;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }


        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }

            this.car = car;
        }
    }
}