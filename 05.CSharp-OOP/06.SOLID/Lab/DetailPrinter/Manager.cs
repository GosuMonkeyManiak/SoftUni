using System;
using System.Collections.Generic;
using System.Text;

namespace DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents)
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Join(Environment.NewLine, Documents));

            return sb.ToString();
        }
    }
}