using System;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private Wall wall;
        private const char foodSymbol = '$';
        private const int foodPoint = 2;
        private const ConsoleColor color = ConsoleColor.DarkMagenta;

        public FoodDollar(Wall wall) 
            : base(wall, foodSymbol, foodPoint, color)
        {
            this.wall = wall;
        }
    }
}