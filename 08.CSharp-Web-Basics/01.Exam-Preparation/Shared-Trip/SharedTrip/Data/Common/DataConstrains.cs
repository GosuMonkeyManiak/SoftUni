namespace SharedTrip.Data.Common
{
    public static class DataConstrains
    {
        public const int DefaultIdMaxLength = 36;
        public const string DateTimeFormat = "dd.MM.yyyy HH:mm";

        public static class UserValidations
        {
            public const int UsernameMinLength = 5;
            public const int UsernameMaxLength = 20;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 64;
        }

        public static class TripValidations
        {
            public const int SeatsMinLength = 2;
            public const int SeatsMaxLength = 6;
            public const int DescriptionMaxLength = 80;
        }
    }
}
