namespace SharedTrip.Services.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IValidationService
    {
        (bool, IEnumerable<string>) IsModelValid(object model);

        bool IsDateTimeValid(string dateTime, string format);
    }
}
