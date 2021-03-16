using System;
using Recharge.Contracts;

namespace Recharge.Models
{
    public class Employee : Worker, ISleeper
    {
        public Employee(string id)
            : base(id)
        {
        }


        public void Sleep()
        {
            Console.WriteLine("Sleep");
        }
    }
}