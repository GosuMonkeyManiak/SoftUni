using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilterModule
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            List<Filters> filters = new List<Filters>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Print")
                {   
                    break;
                }

                string command = tokens[0]; //add or remove
                string filterType = tokens[1]; //starts with, ends with, ...
                string filterParameter = tokens[2]; //string or int for length

                if (command.ToLower() == "remove filter")
                {
                    //check if have a filter with "Add" also with same parameter like current command
                    //will be valid
                    //won't be asked to remove non-existent filter

                    Func<string, bool> func = GetFilter(filterType, filterParameter);

                    Filters filterToRemove = new Filters()
                    {
                        FilterCommand = "Add filter",
                        FilterType = filterType,
                        FilterParameter = filterParameter,
                        condition = func
                    };

                    if (filters.Exists(x => x.FilterCommand == filterToRemove.FilterCommand &&
                                   x.FilterType == filterToRemove.FilterType &&
                                   x.FilterParameter == filterToRemove.FilterParameter))
                    {
                        filters.RemoveAll(x => x.FilterCommand == filterToRemove.FilterCommand &&
                                   x.FilterType == filterToRemove.FilterType &&
                                   x.FilterParameter == filterToRemove.FilterParameter);
                    }
                    
                    continue;
                }

                //HERE -> command == "add filter"
                Func<string, bool> funcFilter = GetFilter(filterType, filterParameter);

                Filters filterInfo = new Filters() 
                {
                    FilterCommand = command,
                    FilterType = filterType,
                    FilterParameter = filterParameter,
                    condition = funcFilter
                };


                if (filters.Exists(x => x.FilterCommand == filterInfo.FilterCommand &&
                                   x.FilterType == filterInfo.FilterType &&
                                   x.FilterParameter == filterInfo.FilterParameter) == false) 
                {
                    filters.Add(filterInfo);
                }
                
            }

            //place the filter
            List<string> filtered = PlaceTheFilters(guests, filters);
            Console.WriteLine(string.Join(" ", filtered));
        }

        static List<string> PlaceTheFilters(List<string> guests, List<Filters> filters)
        {
            List<string> filtered = new List<string>();

            bool isHaveToAdd = true;

            for (int i = 0; i < guests.Count; i++)
            {
                foreach (var filter in filters)
                {
                    if (filter.condition(guests[i]))
                    {
                        isHaveToAdd = false;
                        break;
                    }
                }

                if (isHaveToAdd)
                {
                    filtered.Add(guests[i]);
                }

                isHaveToAdd = true;
            }

            return filtered;
        }

        static Func<string, bool> GetFilter(string filterType, string filterParameter)
        {
            switch (filterType.ToLower())
            {
                case "starts with": return x => x.Substring(0, filterParameter.Length) == filterParameter;
                case "ends with": return x => x.Substring(x.Length - filterParameter.Length, filterParameter.Length) == filterParameter;
                case "length": return x => x.Length == int.Parse(filterParameter);
                case "contains": return x => x.Contains(filterParameter);
                default: return null;
            }
        }
    }
}
