using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPrograms
{
    class Program
    {
        
        static void Main(string[] args)
        {
            AssignmentNo1();
        }
         

        public static void AssignmentNo1()
        {
            Assignment1 assign = new Assignment1();

            restart:
            Console.Write(@"Please Enter A Question Number, OR type 'END' to exit: ");
            String readIt = Console.ReadLine().ToString();
            clearConsole(readIt);
            if (readIt == "help")
            {
                Console.WriteLine(@"
            0: Clear Screen
            1: Add Two Numbers
            2: Area of Rectangle
            3: Area of Circle
            4: Power of Number
            5: Byte Ram Filler
            6: Binary Search
            7: Greatest Common Divisor (GCD)
            8: Generate Random Number
            9: Convert Number to Words
           40: Change Received while shopping
           41: Dollar to Rupee (Rupee to Words)
            END: Exit
            ");
                goto restart;
            }
            else if (readIt == "END" || readIt == "end")
            {
            }
            else
            {
                try
                {
                    Int32 qNumber = Int32.Parse(readIt);
                    Console.WriteLine(" ");
                    switch (qNumber)
                    {
                        case 1:
                            assign.Question1();
                            break;

                        case 2:
                            assign.Question2();
                            break;

                        case 3:
                            assign.Question3();
                            break;

                        case 4:
                            assign.Question4();
                            break;

                        case 5:
                            assign.Question5();
                            break;

                        case 6:
                            assign.Question6();
                            break;

                        case 7:
                            assign.Question7();
                            break;

                        case 8:
                            assign.Question8();
                            break;

                        case 9:
                            assign.Question9();
                            break;

                        case 40:
                            assign.Question40();
                            break;

                        case 41:
                            assign.Question41();
                            break;

                        case 42:
                            assign.Question42();
                            break;

                        case 0:
                            Console.Clear();
                            break;

                        default:
                            assign.PrintLine("Question Does Not Exist:");
                            break;
                    }

                    goto restart;
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Restarting Again....."); Console.WriteLine(" "); goto restart;
                }
            }
        }

        public static void clearConsole(String clean)
        {
            if ("cls" == clean ||  "clear" == clean || "clean" == clean || "clrscr" == clean)
            {
                Console.Clear();
            }
        }

        public static void helper()
        {
            String readIt = Console.ReadLine().ToString();
            if (readIt == "help")
            {
                Console.WriteLine(@"
            0: Clear Screen
            1: Add Two Numbers
            2: Area of Rectangle
            3: Area of Circle
            4: Power of Number
            END: Exit
            ");
            }
            if (readIt == "END" || readIt == "end")
            {

            }
        }
    }
}
