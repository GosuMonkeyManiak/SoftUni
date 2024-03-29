﻿using System.Text;
using Logger.Contracts;

namespace Logger.Layouts
{
    public class HtmlLayout : ILayout
    {
        public string CreateMessage(string date, string reportLevel, string msg)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<logHtml>");
            sb.AppendLine($"   <date>{date}</date>");
            sb.AppendLine($"   <level>{reportLevel}</level>");
            sb.AppendLine($"   <message>{msg}</message>");
            sb.AppendLine("</logHtml>");

            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            return $"Layout type: {this.GetType().Name},";
        }
    }
}