namespace PetStore.Constants
{
    public static class GlobalConstants
    {
        //Pet
        public const int Pet_Name_Max_Length = 45;

        //Gender
        public const int Gender_Name_Max_Length = 6;

        //PetType
        public const int PetType_Name_Max_Length = 40;

        //Breed
        public const int Breed_Name_Max_Length = 40;

        //Food
        public const int Food_Name_Max_Length = 150;

        //Distributors
        public const int Distributor_Name_Max_Length = 70;

        //Toy
        public const int Toy_Name_Max_Length = 100;

        //Decoration
        public const int Decoration_Name_Max_Length = 50;

        //ServiceType
        public const int ServiceType_Name_Max_Length = 60;

        //User
        public const int User_Phone_Max_Length = 20;

        //Welcome view
        public const string Welcome_Nav = "1.Login\r\n2.Register\r\n3.Exit";

        public const string Welcome_Title = "Welcome to PetStore";

        public const string Welcome_Nav_Incorrect_Entered_Value =
            "Entered value has to be a one symbol!" + Press_Any_Key;

        public const int Login_Number = 1;
        public const int Register_Number = 2;
        public const int Exit_Number = 3;

        //User iterations
        public const string Press_Any_Key = "Press any key to continue...";

        public const string Press_Enter_To_Try_Again = "Press Enter to try again.";

        public const string Press_BackSpace_To_Register = "Or press backspace to go back.";

        //Login
        public const string Login_Successfully = "Welcome back!" + Press_Any_Key;

        public const string Incorrect_Username_Or_Password = "Incorrect Username or Password!" + Press_Enter_To_Try_Again + Press_BackSpace_To_Register;

        public const string Login_Title = "Login";

        //Register
        public const string Register_Successfully = "Successfully register!" + Press_Any_Key;

        public const string Register_Title = "Register";

        //Login and Register
        public const string Username_Field = "Username: ";
        public const string Password_Field = "Password: ";
    }
}
