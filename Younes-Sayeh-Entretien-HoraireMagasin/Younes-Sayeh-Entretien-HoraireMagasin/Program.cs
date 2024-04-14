using System;

namespace Younes_Sayeh_Entretien_HoraireMagasin
{
    class Program
    {
        // Entering all the date in a Tuple with 3 elements : the day of the week, the opening hour and the closing hour
        static (DayOfWeek, TimeSpan, TimeSpan)[] openingHours = {
            (DayOfWeek.Monday, TimeSpan.Parse("08:00"), TimeSpan.Parse("16:00")),
            (DayOfWeek.Wednesday, TimeSpan.Parse("08:00"), TimeSpan.Parse("16:00")),
            (DayOfWeek.Friday, TimeSpan.Parse("08:00"), TimeSpan.Parse("16:00")),
            (DayOfWeek.Tuesday, TimeSpan.Parse("08:00"), TimeSpan.Parse("12:00")),
            (DayOfWeek.Tuesday, TimeSpan.Parse("14:00"), TimeSpan.Parse("18:00")),
            (DayOfWeek.Thursday, TimeSpan.Parse("08:00"), TimeSpan.Parse("12:00")),
            (DayOfWeek.Thursday, TimeSpan.Parse("14:00"), TimeSpan.Parse("18:00")),
            (DayOfWeek.Saturday, TimeSpan.Parse("08:00"), TimeSpan.Parse("12:00"))
        };

        /// <summary>
        /// Verify if the input match with the date
        /// </summary>
        static bool IsOpenOn(DateTime date)
        {
            foreach (var openingHour in openingHours)
            {
                // Check if the input match wtih the opening date
                if (openingHour.Item1 == date.DayOfWeek && date.TimeOfDay >= openingHour.Item2 && date.TimeOfDay <= openingHour.Item3)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Return the next opening date based on the input
        /// </summary>
        static DateTime NextOpeningDate(DateTime date)
        {
            foreach (var openingHour in openingHours)
            {
                // Check for all the day in the morning
                while (openingHour.Item1 == date.DayOfWeek && date.TimeOfDay >= openingHour.Item2 && date.TimeOfDay <= openingHour.Item3)
                {
                    // Check if the day is saturday to add 2 days to avoid sunday
                    if (date.DayOfWeek == DayOfWeek.Saturday)
                    {
                        return date.Date.AddDays(2).Add(date.TimeOfDay);
                    }
                    else
                    {
                        return date.Date.AddDays(1).Add(date.TimeOfDay);
                    }
                }
            }
            return date.Date.AddDays(0.5);
        }

        static void Main(string[] args)
        {
            // Changing title of the program
            Console.Title = "Horaire d'ouverture d'un magasin";

            // Create the dates
            DateTime wednesday = DateTime.Parse("2024-02-21T07:45:00.000");
            DateTime thursday = DateTime.Parse("2024-02-22T12:22:11.824");
            DateTime saturday = DateTime.Parse("2024-02-24T09:15:00.000");
            DateTime sunday = DateTime.Parse("2024-02-25T09:15:00.000");
            DateTime fridayMorning = DateTime.Parse("2024-02-23T08:00:00.000");
            DateTime mondayMorning = DateTime.Parse("2024-02-26T08:00:00.000");
            DateTime thursdayAfternoon = DateTime.Parse("2024-02-22T14:00:00.000");
            
            // Display if it's open
            Console.WriteLine(IsOpenOn(wednesday));
            Console.WriteLine(IsOpenOn(thursday));
            Console.WriteLine(IsOpenOn(sunday));

            // Display the next opening date
            Console.WriteLine(NextOpeningDate(thursdayAfternoon));
            Console.WriteLine(NextOpeningDate(saturday));
            Console.WriteLine(NextOpeningDate(thursday));

            Console.ReadLine();
        }
    }
}
