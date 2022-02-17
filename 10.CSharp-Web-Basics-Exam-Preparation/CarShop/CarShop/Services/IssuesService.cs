namespace CarShop.Services
{
    using Contracts;
    using System;
    using System.Linq;
    using Data;
    using Data.Model;

    public class IssuesService : IIssuesService
    {
        private readonly CarShopDbContext dbContext;

        public IssuesService(CarShopDbContext dbContext)
            => this.dbContext = dbContext;

        public void AddIssue(string carId, string description)
        {
            var car = this.dbContext
                .Cars
                .FirstOrDefault(c => c.Id == carId);

            var issue = new Issue()
            {
                Description = description,
                CarId = carId,
            };

            this.dbContext
                .Issues
                .Add(issue);

            this.dbContext.SaveChanges();
        }

        public bool IsIssueExist(string issueId)
            => this.dbContext
                .Issues
                .FirstOrDefault(i => i.Id == issueId) != null;

        public void Fix(string issueId)
        {
            var issue = this.dbContext
                .Issues
                .FirstOrDefault(i => i.Id == issueId);

            issue.IsFixed = true;

            this.dbContext.SaveChanges();
        }

        public void Delete(string issueId)
        {
            var issue = this.dbContext
                .Issues
                .FirstOrDefault(i => i.Id == issueId);

            this.dbContext
                .Issues
                .Remove(issue);

            this.dbContext.SaveChanges();
        }
    }
}
