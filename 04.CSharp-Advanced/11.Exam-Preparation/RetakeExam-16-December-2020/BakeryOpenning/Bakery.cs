using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Capacity = capacity;
            data = new List<Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get => data.Count; }

        public void Add(Employee employee)
        {
            if (Capacity == data.Count)
            {
                return;
            }

            data.Add(employee);
        }

        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(x => x.Name == name);

            if (employee != null)
            {
                data.Remove(employee);
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee() => data.OrderByDescending(x => x.Age).FirstOrDefault();

        public Employee GetEmployee(string name) => data.FirstOrDefault(x => x.Name == name);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var employee in data)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString();
        }
    } 
}
