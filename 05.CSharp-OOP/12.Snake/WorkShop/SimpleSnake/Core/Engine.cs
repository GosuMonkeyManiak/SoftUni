using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Point[] directions;
        private Direction direction;
        private Snake snake;
        private Wall wall;
        private int currentPoints;
        private double sleepTime;

        public Engine(Wall wall, Snake snake)
        {
            directions = new Point[4];
            this.snake = snake;
            this.wall = wall;
            direction = Direction.Right;
            sleepTime = 100;
        }

        public void Run()
        {
            this.CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = snake.IsMoving(this.directions[(int)direction]);

                if (currentPoints != snake.Points)
                {
                    GetStatistic();
                }

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(10, 10);
            Console.Write("Game over");
            Environment.Exit(0);
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 2;
            int topY = 6;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue! y/n");

            //hide inPut
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleKeyInfo inPut = Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Black;

            if (inPut.Key == ConsoleKey.Y)
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void CreateDirections()
        {
            this.directions[0] = new Point(1, 0);
            this.directions[1] = new Point(-1, 0);
            this.directions[2] = new Point(0, 1);
            this.directions[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            Console.CursorVisible = false;

            ConsoleKeyInfo userInPut = Console.ReadKey();

            if (userInPut.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInPut.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInPut.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInPut.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }

        }

        private void GetStatistic()
        {
            currentPoints = snake.Points;
            int leftX = this.wall.LeftX + 2;
            int topY = 2;

            Console.SetCursorPosition(leftX, topY);
            Console.Write(new string('-', 18));
            topY++;
            Console.SetCursorPosition(leftX, topY);
            Console.Write($" Player points: {snake.Points}");
            topY++;
            Console.SetCursorPosition(leftX, topY);
            Console.Write($" Player level: {snake.Points / 10}");
            topY++;
            Console.SetCursorPosition(leftX, topY);
            Console.Write(new string('-', 18));
        }
    }
}