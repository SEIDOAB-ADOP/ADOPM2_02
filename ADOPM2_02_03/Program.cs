using System;

namespace ADOPM2_02_03
{
    class Program
    {
        record RectangleRecord (double Width, double Height);

        static void Main(string[] args)
        {
            var rr1 = new RectangleRecord (400,100);
            var rr2 = rr1;

            var rr3 = rr2 with { Width = 800 };
            var rr4 = rr2 with { Height = 200 };

            Console.WriteLine(rr1);
            Console.WriteLine(rr1 == rr2);
            Console.WriteLine(rr1 == rr3);



            (double width, double height) = rr1;
            Console.WriteLine(width);
            Console.WriteLine(height);
        }
    }
}
//Exercises
//1.	Make the Apple type in ADOPM2_01_02  immutable using record? 
//		Demonstrate immutability by assignment and printout.
