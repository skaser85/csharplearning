using System;

namespace CalcAgeInSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your birthdate (e.g., 11/13/1985 (US date format)...");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            TimeSpan interval = DateTime.Now - birthDate;
            int days = interval.Days;
            int hours = interval.Hours;
            int mins = interval.Minutes;
            int secs = interval.Seconds;
            int total = (secs) + (mins * 60) + (hours * 60 * 60) + (days * 24 * 60 * 60);
            Console.WriteLine($"It has been {total.ToString("#,#")} seconds since {birthDate.ToShortDateString()}");
        }
    }
}
