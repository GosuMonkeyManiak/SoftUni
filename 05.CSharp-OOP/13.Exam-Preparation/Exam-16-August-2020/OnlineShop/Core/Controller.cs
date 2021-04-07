using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = null;

            if (computerType == ComputerType.DesktopComputer.ToString())
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == ComputerType.Laptop.ToString())
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            if (peripherals.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = null;

            if (peripheralType == PeripheralType.Headset.ToString())
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Keyboard.ToString())
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Monitor.ToString())
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Mouse.ToString())
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            if (computers.Any(c => c.Id == computerId) == false)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            computers.First(c => c.Id == computerId).AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (computers.Any(c => c.Id == computerId) == false)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            string computerType = computers.First(c => c.Id == computerId).GetType().Name;

            if (peripherals.Any(p => p.GetType().Name == peripheralType) == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType,
                    computerType, computerId));
            }

            IPeripheral peripheral = peripherals.First(c => c.GetType().Name == peripheralType);

            computers.First(c => c.Id == computerId).RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            if (components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = null;

            if (componentType == ComponentType.CentralProcessingUnit.ToString())
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.Motherboard.ToString())
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.PowerSupply.ToString())
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.RandomAccessMemory.ToString())
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.SolidStateDrive.ToString())
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.VideoCard.ToString())
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            if (computers.Any(c => c.Id == computerId) == false)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            computers.First(c => c.Id == computerId).AddComponent(component);
            components.Add(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (computers.Any(c => c.Id == computerId) == false)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            string computerType = computers.First(c => c.Id == computerId).GetType().Name;

            if (components.Any(c => c.GetType().Name == componentType) == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, computerType,
                    computerId));
            }

            IComponent component = components.First(c => c.GetType().Name == componentType);

            computers.First(c => c.Id == computerId).RemoveComponent(componentType);
            components.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string BuyComputer(int id)
        {
            if (computers.Any(c => c.Id == id) == false)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = computers.First(c => c.Id == id);
            computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = computers
                .Where(c => c.Price <= budget)
                .OrderByDescending(c => c.OverallPerformance)
                .FirstOrDefault();

            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            if (computers.Any(c => c.Id == id) == false)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return computers.First(c => c.Id == id).ToString();
        }
    }
}