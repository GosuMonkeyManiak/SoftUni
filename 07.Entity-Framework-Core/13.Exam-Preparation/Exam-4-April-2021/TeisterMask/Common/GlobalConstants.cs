using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.Common
{
    public static class GlobalConstants
    {
        //Employee
        public const int Employee_Username_Min_Length = 3;
        public const int Employee_Username_Max_Length = 40;
        public const string Employee_Username_Regex = @"^[A-Za-z0-9]+$";
        public const int Employee_Phone_Max_Length = 12;
        public const string Employee_Phone_Regex = @"^\d{3}\-\d{3}\-\d{4}$";

        //Project
        public const int Project_Name_Min_Length = 2;
        public const int Project_Name_Max_Length = 40;

        //Task
        public const int Task_Name_Min_Length = 2;
        public const int Task_Name_Max_Length = 40;
    }
}
