using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            Capacity = capacity;
            Type = type;
            data = new List<Car>();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count { get => data.Count; }

        public void Add(Car car)
        {
            if (data.Count == Capacity)
            {
                return;
            }

            data.Add(car);
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            if (car != null)
            {
                data.Remove(car);
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
