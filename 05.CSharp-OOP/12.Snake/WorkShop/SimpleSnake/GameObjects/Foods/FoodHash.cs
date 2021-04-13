using System;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private Wall wall;
        private const char foodSymbol = '#';
        private const int foodPoint = 1;
        private const ConsoleColor color = ConsoleColor.Cyan;

        public FoodHash(Wall wall) 
            : base(wall, foodSymbol, foodPoint, color)
        {
        }
    }
}