namespace MSS.CrossCuttingConcerns.Infrastructure.ConstantData
{
    public sealed class Endpoints
    {
        private Endpoints() { }

#if DEBUG
        public const string API_BASE_ADDRESS = "https://localhost:5001";
        public const string BLAZOR_WEB_BASE_ADDRESS = "https://localhost:44326";
#else
        public const string API_BASE_ADDRESS = "https://84.105.128.107";
        public const string BLAZOR_WEB_BASE_ADDRESS = "N/A";
#endif
        public const string API_CONTROLLER_ACCOUNT = "account";
        public const string API_CONTROLLER_IDENTITY = "identity";
        public const string API_CONTROLLER_CREDITS = "credits";
        public const string API_CONTROLLER_EDIT_PAGE = "editpage";
    }
}
