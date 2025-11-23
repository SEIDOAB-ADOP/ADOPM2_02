using System;

namespace ADOPM2_02_05
{
    class Program
    {
        record RectangleRecord(double Height)
        {
            private double _width;
            public double Width
            {
                get => _width;
                init
                {
                    if (value == 0) throw new ArgumentNullException();
                    _width = value;
                }
            }
 
            public double Area => Width * Height;
            public RectangleRecord GetQuad()
            {
                RectangleRecord result = this with { Width = this.Width * 2, Height = this.Height * 2 };
                return result;
            }
        }

        static void Main(string[] args)
        {
            var rr1 = new RectangleRecord(200) { Width = 300 };
            var rr2 = rr1;
            Console.WriteLine(rr1);
            Console.WriteLine(rr1 == rr2);  // true

            Console.WriteLine();
            rr2 = rr1 with { Width = rr1.Height*10 };
            Console.WriteLine(rr1);
            Console.WriteLine(rr2);

            Console.WriteLine();
            Console.WriteLine(rr1.GetQuad());
            Console.WriteLine(rr2);
            Console.WriteLine(rr1 == rr2);  // false

            //(double width, double height) = rr1;  // Error: Width is no longer part of the generated deconstructor
        }
    }
}
