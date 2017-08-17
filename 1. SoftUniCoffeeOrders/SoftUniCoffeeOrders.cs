using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Numerics;

class SoftUniCoffeeOrders
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var totalCoffeePrice = 0m;

        for (int i = 0; i < n; i++)
        {
            decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
            var orderDate = Console.ReadLine();
            var capsulesCount = int.Parse(Console.ReadLine());

            var date = DateTime.ParseExact(orderDate, "d/M/yyyy", CultureInfo.InvariantCulture);
            var daysOfMonth = DateTime.DaysInMonth(date.Year, date.Month);

            var coffeePrice = (daysOfMonth * (decimal)capsulesCount) * pricePerCapsule;
            totalCoffeePrice += coffeePrice;

            Console.WriteLine($"The price for the coffee is: ${coffeePrice:f2}");
        }

        Console.WriteLine($"Total: ${totalCoffeePrice:f2}");
    }
}

