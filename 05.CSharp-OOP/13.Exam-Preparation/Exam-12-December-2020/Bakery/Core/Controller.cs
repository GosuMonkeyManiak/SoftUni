using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal inCome;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type == BakedFoodType.Bread.ToString())
            {
                food = new Bread(name, price);
            }
            else if (type == BakedFoodType.Cake.ToString())
            {
                food = new Cake(name, price);
            }

            bakedFoods.Add(food);

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == DrinkType.Tea.ToString())
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == DrinkType.Water.ToString())
            {
                drink = new Water(name, portion, brand);
            }

            drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == TableType.InsideTable.ToString())
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == TableType.OutsideTable.ToString())
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            tables.Add(table);

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables
                .Where(t => t.IsReserved == false)
                .Where(t => t.Capacity >= numberOfPeople)
                .FirstOrDefault();

            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);

            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            if (tables.Any(t => t.TableNumber == tableNumber) == false)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (bakedFoods.Any(f => f.Name == foodName) == false)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            IBakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);
            tables.FirstOrDefault(t => t.TableNumber == tableNumber).OrderFood(food);

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            if (tables.Any(t => t.TableNumber == tableNumber) == false)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (drinks.Any(d => d.Name == drinkName && d.Brand == drinkBrand) == false)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            tables.FirstOrDefault(t => t.TableNumber == tableNumber).OrderDrink(drink);

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, drinkName) + $" {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            if (tables.Any(t => t.TableNumber == tableNumber) == false)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            var bill = tables.FirstOrDefault(t => t.TableNumber == tableNumber).GetBill();
            inCome += bill;
            tables.FirstOrDefault(t => t.TableNumber == tableNumber).Clear();

            return $"Table: {tableNumber}" + Environment.NewLine +
                   $"Bill: {bill:f2}".TrimEnd();

        }

        public string GetFreeTablesInfo()
        {
            var freeTable = tables
                .Where(t => t.IsReserved == false)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var table in freeTable)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, inCome);
        }
    }
}