namespace MSS.CrossCuttingConcerns.Infrastructure.ConstantData
{
    public sealed class Validation
    {
        private Validation() { }

        public const string PASSWORD_ERROR_MESSAGE = "This password does not meet the requirements";
        public const string VALID_PASSWORD_PATTERN = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,54}$";
        public static readonly string[] VALID_PASSWORD_REQUIREMENTS = new[]
        {
            "Contain atleast one upper case letter",
            "Contain atleast one lower case letter",
            "Contain atleast one diget",
            "Contain atleast one special character",
            "Have a minimum length of 8",
            "Have a maximum length of 54"
        };

        public static readonly string[] VALID_EMAIL_DOMAINS = new string[] { "gmail", "yahoo", "hotmail", "outlook", "icloud", "me", "mac", "aol", "msn", "wanadoo", "comcast", "live", "rediffmail", "outlook", "googlemail", "tiscali", "t-online", "telenet" };
        public const byte NAME_MAX_LENGTH = 20;
        public const byte NAME_MIN_LENGTH = 1;
    }
}
