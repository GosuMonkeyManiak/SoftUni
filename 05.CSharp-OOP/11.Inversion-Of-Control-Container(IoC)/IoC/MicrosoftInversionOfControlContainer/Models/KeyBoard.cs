using MicrosoftInversionOfControlContainer.Contracts;

namespace MicrosoftInversionOfControlContainer.Models
{
    public class KeyBoard : IKeyBoard
    {
        private ICable _cable;

        public KeyBoard(ICable cable)
        {
            _cable = cable;
        }
    }
}