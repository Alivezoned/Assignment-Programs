using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPrograms
{
    class TestFunctions
    {

        int step = 0;

        public void MainProgram(int number)
        {
            step = 0;
            NumberToWords(number);
        }

        private String NumberToWords(int number)
        {
            if (number == 0)
            {
                return "zero";
            }

            if (number < 0)
            {
                return "minus " + NumberToWords(Math.Abs(number));
            }

            string words = "";

            if ((number / 1000000) > 0)
            {
                print("---------Million START---------");
                print(number.ToString()); step++;

                words += NumberToWords(number / 1000000) + " Million ";
                print(words); step++;

                number %= 1000000;
                print(number.ToString()); step++;
                print("---------Million END---------");
            }

            if ((number / 1000) > 0)
            {
                print("---------Thousand START---------");
                print(number.ToString()); step++;

                words += NumberToWords(number / 1000) + " Thousand ";
                print(words + "  _words += NumberToWords(" + number + " / 1000)"); step++;

                number %= 1000;
                print(number.ToString() + "  _number %= 1000;"); step++;
                print("---------Thousand END---------");
            }

            if ((number / 100) > 0)
            {
                print("---------100 START---------");
                print(number.ToString()); step++;

                words += NumberToWords(number / 100) + " Hundred ";
                print(words + "  _words += NumberToWords("+number+" / 100)"); step++;

                number %= 100;
                print(number.ToString() + "  _number %= 100"); step++;
                print("---------100 END---------");
            }

            if (number > 0)
            {
                print(" Print Word: " + number.ToString()); step++;
                print(" Print Word: " + words); step++;
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                {
                    words += unitsMap[number];
                    print(" Print Word: " + words); step++;
                }
                else
                {
                    print(" Print Word: " + words); step++;

                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                    {
                        words += "-" + unitsMap[number % 10];
                        print(" Print Word: " + words); step++;
                    }
                }
            }
            print(" Print Word: " + words); step++;

            return words;
        }

        private void print(String text)
        {
            Console.WriteLine("Step "+step+":- "+text);
        }
    }
}
