using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
    
        static List<int> CrontabFieldValues(string field, int minValue, int maxValue)
        {
            if (field == "*")
            {
                return Enumerable.Range(minValue, maxValue - minValue + 1).ToList();
            }
            List<int> values = new List<int>();
            string[] subFields = field.Split(',');
            foreach (string subField in subFields)
            {
                string patternRange = @"(\d+)-(\d+)";
                Match matchRange = Regex.Match(subField, patternRange, RegexOptions.IgnoreCase);
                string patternDevision = @"^\*/(\d+)";
                Match matchDevision = Regex.Match(subField, patternDevision, RegexOptions.IgnoreCase);
                if (matchRange.Success)
                {
                    string[] range = subField.Split("-");
                    int start = int.Parse(range[0]);
                    int end = int.Parse(range[1]);
                    values.AddRange(Enumerable.Range(start, end - start + 1));
                }
                else if (matchDevision.Success)
                {
                    int step = int.Parse(subField.Substring(2));
                    values.AddRange(Enumerable.Range(minValue, maxValue - minValue + 1).Where(x => (x - minValue) % step == 0));
                }
                else
                {
                    values.Add(int.Parse(subField));
                }
            }
            return values;

        }
        static DateTime ConvertingCrontabDate(string cronExpression, DateTime givenDate)
        {
            string[] cronFields = cronExpression.Split(' ');
            List<int> minutes = CrontabFieldValues(cronFields[0], 0, 59);
            List<int> hours = CrontabFieldValues(cronFields[1], 0, 23);
            List<int> days = CrontabFieldValues(cronFields[2], 1, DateTime.DaysInMonth(givenDate.Year, givenDate.Month));
            List<int> months = CrontabFieldValues(cronFields[3], 1, 12);
            List<DayOfWeek> daysOfWeek = CrontabFieldValues(cronFields[4], 0, 6).Select(d => (DayOfWeek)d).ToList();
            while (true)
            {
                givenDate = givenDate.AddMinutes(-1);
                if (minutes.Contains(givenDate.Minute) &&
                    hours.Contains(givenDate.Hour) &&
                    days.Contains(givenDate.Day) &&
                    months.Contains(givenDate.Month) &&
                    daysOfWeek.Contains(givenDate.DayOfWeek))
                {
                    return givenDate;
                }
            }
        }
        static void Main(string[] args)
        {
            string cronExpression = "* * * * 2"; //You can change this example!
            DateTime givenDate = DateTime.Now;

            DateTime result = ConvertingCrontabDate(cronExpression, givenDate);
            Console.WriteLine("Result: " + result);
        }

        
    }

}
