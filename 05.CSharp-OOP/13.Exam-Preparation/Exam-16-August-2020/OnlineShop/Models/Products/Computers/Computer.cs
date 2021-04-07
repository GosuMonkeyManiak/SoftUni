using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public override decimal Price
        {
            get
            {
                return price + components.Sum(c => c.Price) + peripherals.Sum(p => p.Price);
            }
        }

        public override double OverallPerformance
        {
            get
            {
                if (components.Count == 0)
                {
                    return overallPerformance;
                }

                return overallPerformance + components.Average(c => c.OverallPerformance);
            }
        }

        public void AddComponent(IComponent component)
        {
            if (components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name,
                    this.GetType().Name, Id));
            }

            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Count == 0 || components.Any(c => c.GetType().Name == componentType) == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType,
                    this.GetType().Name, Id));
            }

            IComponent component = components.First(c => c.GetType().Name == componentType);

            components.Remove(component);

            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, this.GetType().Name, Id));
            }

            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Count == 0 || peripherals.Any(p => p.GetType().Name == peripheralType) == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType,
                    this.GetType().Name, Id));
            }

            IPeripheral peripheral = peripherals.First(p => p.GetType().Name == peripheralType);

            peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine(" " + string.Format(SuccessMessages.ComputerComponentsToString, components.Count));
            foreach (var component in components)
            {
                sb.AppendLine("  " + component);
            }

            if (peripherals.Count > 0)
            {
                sb.AppendLine(" " + string.Format(SuccessMessages.ComputerPeripheralsToString, peripherals.Count,
                    peripherals.Average(p => p.OverallPerformance)));
            }
            else
            {
                sb.AppendLine(" " + string.Format(SuccessMessages.ComputerPeripheralsToString, peripherals.Count, 0));
            }

            foreach (var peripheral in peripherals)
            {
                sb.AppendLine("  " + peripheral);
            }

            return sb.ToString().TrimEnd();
        }
    }
}