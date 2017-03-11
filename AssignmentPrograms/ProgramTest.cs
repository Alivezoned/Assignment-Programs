using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPrograms
{
    class ProgramTest
    {
       /* static void Main(string[] args)
        {
            Stuff();
        }*/

        public static void Stuff()
        {
            Start:
            TestFunctions tf = new TestFunctions();

            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            tf.MainProgram(number);

            Console.ReadLine();
            goto Start;
        }
    }
}
