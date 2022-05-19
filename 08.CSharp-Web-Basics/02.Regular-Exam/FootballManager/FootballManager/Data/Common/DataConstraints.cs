namespace FootballManager.Data.Common
{
    public static class DataConstraints
    {
        public const int DefaultIdMaxLength = 36;

        public static class UserConstraints
        {
            public const int UsernameMinLength = 5;
            public const int UsernameMaxLength = 20;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;

            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;
        }

        public static class PlayerConstraints
        {
            public const int FullNameMinLength = 5;
            public const int FullNameMaxLength = 80;

            public const int PositionMinLength = 5;
            public const int PositionMaxLength = 20;

            public const int DescriptionMaxLength = 200;
        }
    }
}
