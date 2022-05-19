namespace CarShop.Data.Common
{
    public static class DataConstraints
    {
        public const int DefaultIdMaxLength = 36;

        public static class UserConstraints
        {
            public const int UsernameMinLength = 4;
            public const int UsernameMaxLength = 20;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;
            public const int HashedPasswordMaxLength = 64;
        }

        public static class CarConstraints
        {
            public const int ModelMinLength = 5;
            public const int ModelMaxLength = 20;

            public const int PlateNumberMaxLength = 8;

        }

        public static class IssueConstraints
        {
            public const int DescriptionMinLength = 5;
        }
    }
}
