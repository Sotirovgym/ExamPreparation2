using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class RageQuit
{
    static void Main()
    {
        var input = Console.ReadLine();

        var currentString = new StringBuilder();
        var result = new StringBuilder();

        var pattern = @"(\D+)(\d+)";
       
        var matched = Regex.Matches(input, pattern);

        foreach (Match match in matched)
        {
            var text = match.Groups[1].Value;
            var count = int.Parse(match.Groups[2].Value);

            for (int i = 0; i < count; i++)
            {
                result.Append(text.ToUpper());
            }
        }
        
        var uniqueSymbols = result.ToString().Distinct().Count();

        Console.WriteLine($"Unique symbols used: {uniqueSymbols}");
        Console.WriteLine(result.ToString());
    }
}

