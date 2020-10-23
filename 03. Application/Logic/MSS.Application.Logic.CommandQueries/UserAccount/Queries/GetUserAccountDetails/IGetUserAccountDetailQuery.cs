namespace MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountDetails
{
    public interface IGetUserAccountDetailQuery
    {
        UserAccountDetailModel Execute(string email);
    }
}