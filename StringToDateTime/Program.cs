using System;
using System.Text;
using StringToDateTime;

namespace StringToDateTime
{
    public enum months
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
}

class Program
{
    static void Main(string[] args)
    {
        var inputDate = "2014-12-22";

        while (inputDate != null && inputDate.ToLower() != "exit")
        {
           
            Console.WriteLine("Enter Date In Format: yyyy-mm-dd:");
            inputDate = Console.ReadLine();
            if (inputDate != null && inputDate.ToLower() == "exit") break;
            var outputDate = ConvertToUsDate(inputDate);

            Console.WriteLine($"-> {outputDate}");
        }

        


    }

    private static string ConvertToUsDate(string inputDate)
    {
        var date = inputDate.Split("-");

        var sb = new StringBuilder();

        sb.Append("US: ");
        sb.Append($"{date[1]}/");
        sb.Append($"{date[2]}/");
        sb.Append($"{date[0]}");
        sb.Append(" UK: ");
        sb.Append($"{date[2]}/");
        sb.Append($"{date[1]}/");
        sb.Append($"{date[0]}");
        sb.Append($" Spoken: ");

        var monthWording = DigitToMonth(date[1]);
        var datePostfix = GetDatePostfix(date[2]);

        sb.Append($"{date[2]}{datePostfix} of {monthWording} ");
        

        sb.Append(date[0]);




        return sb.ToString();
    }

    static string GetDatePostfix(string date)
    {
        var chars = date.ToCharArray();

        return chars.Length switch
        {
            2 when chars[0].Equals('1') => "th",
            2 when chars[1].Equals('1') => "st",
            2 when chars[1].Equals('2') => "nd",
            2 when chars[1].Equals('3') => "rd",
            1 when chars[0].Equals('1') => "st",
            1 when chars[0].Equals('2') => "nd",
            1 when chars[0].Equals('3') => "rd",
            _ => "th"
        };
    }
    static string DigitToMonth(string month)
    {
        var monthNumber = Int32.Parse(month);
        return monthNumber switch
        {
            (int) months.January => "January",
            (int) months.February => "February",
            (int) months.March => "March",
            (int) months.April => "April",
            (int) months.May => "May",
            (int) months.June => "June",
            (int) months.July => "July",
            (int) months.August => "August",
            (int) months.September => "September",
            (int) months.October => "October",
            (int) months.November => "November",
            (int) months.December => "December",
            _ => "Month not recognised!"
        };
    }
}
