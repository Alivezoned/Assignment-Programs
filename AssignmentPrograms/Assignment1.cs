using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPrograms
{
    class Assignment1
    {
        ApiClass api = new ApiClass();
        String line = "_________________________";

        public void Question1()
        {
            Int32 n1 = 0, n2 = 0;
            restart:
            try
            {
                PrintLine("Q1. To Add Two Numbers given by User:-");
                Print("Enter First Number:- ");
                n1 = Int32.Parse(Console.ReadLine());
                Print("Enter Second Number:- ");
                n2 = Int32.Parse(Console.ReadLine());
            }
            catch (Exception) { PrintLine("Please Input Numbers Only "); PrintLine(" "); goto restart; }
            Int32 output = n1 + n2;
            PrintLine("Adding Both:- " + output); PrintLine(" ");
        }

        public void Question2()
        {
            Int32 length=0, width=0;
            restart:
            try
            {
                PrintLine("Q2. To Calculate Area of Rectangle:- ");
                Print("Enter Length:- ");
                length = Int32.Parse(Console.ReadLine());
                Print("Enter Width:- ");
                width = Int32.Parse(Console.ReadLine());
            }
            catch (Exception) { PrintLine("Input Numbers Please.."); PrintLine(" "); goto restart; }
            Int32 output = length * width;
            PrintLine("Area of Rectangle:- " + output); PrintLine(" ");
        }

        public void Question3()
        {
            double area, radius;
            double pi = 3.14159;

            restart:
            try
            {
                PrintLine("Q3. Calculate Area of Circle");
                Print("Enter Radius of the Circle:- ");
                radius = double.Parse(Console.ReadLine());

                double radiusSquare = GetPowerOf(radius, 2);
                area = pi * radiusSquare;
            }
            catch (Exception)
            {
                PrintLine("Error.. Restarting.."); PrintLine(" "); goto restart;
            }

            PrintLine("Area of Circle Is: " + area); PrintLine(" ");
        }

        public void Question4()
        {
            double number, power, output;
            PrintLine("Power of Number");

            Print("Enter a Number:- ");
            number = double.Parse(Console.ReadLine());

            Print("Enter the Power:- ");
            power = double.Parse(Console.ReadLine());

            output = GetPowerOf(number, power);

            PrintLine(number+"^"+power+" = "+output);
        }

        public void Question5()
        {
            int mb = 1;
            int size;

            PrintLine("Fill RAM in MB:");
            Print("Enter Size in Megabytes:- ");

            mb = int.Parse(Console.ReadLine());
            size = 1000000 * mb;

            PrintLine("Filling "+mb+"MB OR "+size+" bytes RAM ..");

            StringBuilder b = new StringBuilder();

            RandomBufferGenerator buffer1 = new RandomBufferGenerator(size);
            byte[] brt = buffer1.GenerateBufferFromSeed(size);

            b.Append(brt);
            Console.ReadKey();
        }

        public void Question6()
        {
            int counter = 0;
            // Binary Search
            PrintLine("Enter Length of Array:- ");
            int arrayLength = Int32.Parse(Console.ReadLine());

            int[] xArray = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                xArray[i] = i + 5;
            }
                int valueToFind;

                int found = 0;
                int high, low = 0, mid;

                PrintLine("Enter Value To Find:- ");
                valueToFind = Int32.Parse(Console.ReadLine());

                high = valueToFind;
                mid = (high + low) / 2;
                while ((found == 0) && (high >= low))
                {
                    PrintLine("low: " + low + ", mid: " + mid + ", high: " + high);
                    if (valueToFind == xArray[mid])
                    {
                        found = 1;
                    }
                    else if (valueToFind < xArray[mid])
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                    mid = (high + low) / 2;
                    counter += 1;
                }
                PrintLine(counter+" Times");
        }

        public void Question7()
        {
            PrintLine("Greatest Common Divisor (GCD)");
            //GCD for two Nos m and n
            int m, n;
            m = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());

            //m should be greater than n
            int no1, no2;
            if (m > n)
            {
                no1 = m;
                no2 = n;
            }
            else
            {
                no1 = n;
                no2 = m;
            }
            int result = Q7gcd(no1, no2);
            Console.WriteLine("The GCD of {0} and {1} is {2}",m,n,result);
        }

        public void Question8()
        {
            Random rand = new Random();
            int first = rand.Next(1, 100);
            int second = rand.Next(1, 100);
            PrintLine(first + " , " + second);
        }

        public void Question9()
        {
            PrintLine("Convert Number into words");
            long number = long.Parse(Console.ReadLine());

            String a = NumberToWords(number);
            PrintLine(a);
        }

        private string NumberToWords(long number)
        {
            string words = "";
            
            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            int[] NoInTens = new int[] { 10000000, 100000, 1000, 100 };
            var NoInWords = new[] { " crore ", " lakh ", " thousand ", " hundred " };

            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            for (int i = 0; i < NoInTens.Length; i++)
            {
                if ((number / NoInTens[i]) > 0)
                {
                    words += NumberToWords(number / NoInTens[i]) + NoInWords[i];
                    number %= NoInTens[i];
                }
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public void Question40()
        {
            PrintLine(line);
            PrintLine("Change received"); PrintLine(" ");
            
            Print("Enter total cost of item/s :- ");
            int cost = int.Parse(Console.ReadLine()); PrintLine(" ");

            Print("Enter amount given :- ");
            int given = int.Parse(Console.ReadLine());

            int[] denomination = new int[] { 1000,100,50,20,10,5,2,1 };

            int remain = given - cost;
            int change = 0;

            foreach (int den in denomination)
            {
                if (remain >= den)
                {
                    change = remain / den;
                    remain = (remain) - (change * den);
                    PrintLine(den + " Rupees :- " + change);
                }
            }
            PrintLine("Total Change:- " + (given-cost));
            PrintLine(" ");
        }

        public void Question41()
        {
            // 1 USD = 68 INR
            int dollar = api.GetCurrency();

            Print("Enter amount in dollars:- ");
            long amount = long.Parse(Console.ReadLine());

            amount *= dollar;

            PrintLine(amount.ToString());
            PrintLine(NumberToWords(amount));
   
            PrintLine(line);
        }

        public void Question42()
        {
            api.AsciiArt();
        }

        // Finds out power of a number
        private double GetPowerOf(double number, double power)
        {
            double output;
            output = number;

            for (int i = 2; i <= power; i++)
            {
                output = output * number;
            }

            return output;
        }
        private static int Q7gcd(int no1, int no2)
        {
            int rem = 5;
            while (no2 > 0)
            {
                rem = no1 % no2;
                if (rem == 0)
                    return no2;
                no1 = no2;
                no2 = rem;

            }
            //GCD of any Number with 0 is the Number itself.
            return no1;
        }

        public void Print(String text)
        {
            Console.Write(text);
        }
        public void PrintLine(String text)
        {
            Console.WriteLine(text);
        }
    }

    public class RandomBufferGenerator
    {
        private readonly Random _random = new Random();
        private readonly byte[] _seedBuffer;

        public RandomBufferGenerator(int maxBufferSize)
        {
            _seedBuffer = new byte[maxBufferSize];

            _random.NextBytes(_seedBuffer);
        }

        public byte[] GenerateBufferFromSeed(int size)
        {
            int randomWindow = _random.Next(0, size);

            byte[] buffer = new byte[size];

            Buffer.BlockCopy(_seedBuffer, randomWindow, buffer, 0, size - randomWindow);
            Buffer.BlockCopy(_seedBuffer, 0, buffer, size - randomWindow, randomWindow);

            return buffer;
        }
    }
}
