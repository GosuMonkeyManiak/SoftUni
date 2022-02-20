namespace FootballManager.Services.Contracts
{
    using System.Collections.Generic;

    public interface IValidationService
    {
        (bool, IEnumerable<string>) IsModelValid(object model);

        bool IsPositionValid(string position);
    }
}
