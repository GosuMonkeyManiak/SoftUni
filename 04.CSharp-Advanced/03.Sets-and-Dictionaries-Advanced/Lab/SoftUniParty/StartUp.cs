using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<string> guestID = new HashSet<string>();

            bool isSecondEnd = false;

            while (true)
            {
                string inPut = Console.ReadLine();
                if (inPut == "END")
                {
                    break;
                }

                if (inPut == "PARTY")
                {
                    while (true)
                    {
                        string id = Console.ReadLine();
                        if (id == "END")
                        {
                            isSecondEnd = true;
                            break;
                        }

                        if (guestID.Contains(id))
                        {
                            guestID.Remove(id);
                        }
                    }
                }
                else if (inPut.Length == 8)
                {
                    guestID.Add(inPut);
                }

                if (isSecondEnd)
                {
                    break;
                }
            }

            Console.WriteLine(guestID.Count);
            List<string> guests = guestID.ToList();

            List<string> VIP = guests.Where(x => Char.IsDigit(x[0]) == true).ToList();
            List<string> regulars = guests.Where(x => Char.IsDigit(x[0]) == false).ToList();

            foreach (var vip in VIP)
            {
                Console.WriteLine(vip);
            }

            foreach (var regular in regulars)
            {
                Console.WriteLine(regular);
            }

        }
    }
}
