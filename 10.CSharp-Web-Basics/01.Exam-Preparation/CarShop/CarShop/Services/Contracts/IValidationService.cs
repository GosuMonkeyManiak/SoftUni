namespace CarShop.Services.Contracts
{
    using System.Collections.Generic;

    public interface IValidationService
    {
        (bool, IEnumerable<string>) IsModelValid(object model);

        bool IsUserTypeValid(string typeOfUser);
    }
}
