﻿using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string result = commandInterpreter.Read(Console.ReadLine());

                if (result == null)
                {
                    Environment.Exit(1);
                }

                Console.WriteLine(result);
            }
        }
    }
}