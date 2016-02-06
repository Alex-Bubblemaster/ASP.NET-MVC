namespace BitCalculator.Models
{
    using System;
    using System.Collections.Generic;

    public static class ConversionTypeMultiples
    {
        public static Dictionary<string, double> All(double kilo)
        {
            var listOfUnits = new Dictionary<string, double>();
            listOfUnits.Add("Bit", Math.Pow(kilo, 0) / 8);
            listOfUnits.Add("Byte", Math.Pow(kilo, 0));
            listOfUnits.Add("Kilobit", Math.Pow(kilo, 1) / 8);
            listOfUnits.Add("Kilobyte", Math.Pow(kilo, 1));
            listOfUnits.Add("Megabit", Math.Pow(kilo, 2) / 8);
            listOfUnits.Add("Megabyte", Math.Pow(kilo, 2));
            listOfUnits.Add("Gigabit", Math.Pow(kilo, 3) / 8);
            listOfUnits.Add("Gigabyte", Math.Pow(kilo, 3));
            listOfUnits.Add("Terabit", Math.Pow(kilo, 4) / 8);
            listOfUnits.Add("Terabyte", Math.Pow(kilo, 4));
            listOfUnits.Add("Petabit", Math.Pow(kilo, 5) / 8);
            listOfUnits.Add("Petabyte", Math.Pow(kilo, 5));
            listOfUnits.Add("Exabit", Math.Pow(kilo, 6) / 8);
            listOfUnits.Add("Exabyte", Math.Pow(kilo, 6));
            listOfUnits.Add("Zettabit", Math.Pow(kilo, 7) / 8);
            listOfUnits.Add("Zettabyte", Math.Pow(kilo, 7));
            listOfUnits.Add("Yottabit", Math.Pow(kilo, 8) / 8);
            listOfUnits.Add("Yottabyte", Math.Pow(kilo, 8));

            return listOfUnits;
        }
    }
}