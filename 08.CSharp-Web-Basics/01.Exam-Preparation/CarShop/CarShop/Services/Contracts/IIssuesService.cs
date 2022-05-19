namespace CarShop.Services.Contracts
{
    public interface IIssuesService
    {
        void AddIssue(string carId, string description);

        bool IsIssueExist(string issueId);

        void Fix(string issueId);

        void Delete(string issueId);
    }
}
