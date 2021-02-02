using System;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {  
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            string res = $"Make: {this.Make}" + Environment.NewLine;
            res += $"Model: {this.Model}" + Environment.NewLine;
            res += $"HorsePower: {this.HorsePower}" + Environment.NewLine;
            res += $"RegistrationNumber: {this.RegistrationNumber}";

            return res;
        }
    }
}
