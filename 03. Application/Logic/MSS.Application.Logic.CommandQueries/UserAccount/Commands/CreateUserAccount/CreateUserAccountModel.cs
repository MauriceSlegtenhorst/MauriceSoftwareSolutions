namespace MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount
{
    public sealed class CreateUserAccountModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Affix { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
