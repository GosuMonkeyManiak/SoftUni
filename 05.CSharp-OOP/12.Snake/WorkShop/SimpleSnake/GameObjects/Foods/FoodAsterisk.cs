using System;
using System.Runtime.CompilerServices;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private Wall wall;
        private const char foodSymbol = '*';
        private const int foodPoint = 1;
        private const ConsoleColor color = ConsoleColor.Red;

        public FoodAsterisk(Wall wall)
            : base(wall, foodSymbol, foodPoint, color)
        {
            this.wall = wall;
        }


    }
}