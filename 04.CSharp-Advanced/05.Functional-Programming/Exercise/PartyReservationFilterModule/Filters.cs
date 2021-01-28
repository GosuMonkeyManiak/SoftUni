using System;
using System.Collections.Generic;
using System.Text;

namespace PartyReservationFilterModule
{
    class Filters
    {
        public string FilterCommand { get; set; }

        public string FilterType { get; set; }

        public string FilterParameter { get; set; }

        public Func<string, bool> condition { get; set; }
    }
}
