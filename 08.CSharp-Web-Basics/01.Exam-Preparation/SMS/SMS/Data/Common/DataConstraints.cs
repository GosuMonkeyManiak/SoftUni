namespace SMS.Data.Common
{
    public static class DataConstraints
    {
        public const int DefaultIdMaxLength = 36;

        public static class UserConstrains
        {
            public const int UsernameMinLength = 5;
            public const int UsernameMaxLength = 20;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 20;

            public const int HashedPasswordMaxLength = 64;
        }

        public static class ProductConstrains
        {
            public const int ProductNameMinLength = 4;
            public const int ProductNameMaxLength = 20;
        }
    }
}
