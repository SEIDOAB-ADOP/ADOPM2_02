using System;

namespace ADOPM2_02_04
{
    class Program
    {
        record RectangleRecord(double Width, double Height)
        {
            public double Area => Width * Height;
            public RectangleRecord GetQuad()
            {
                RectangleRecord result = this with { Width = this.Width * 2, Height = this.Height * 2 };
                return result;
            }
        }

        static void Main(string[] args)
        {
            var rr1 = new RectangleRecord(400, 100);
            var rr2 = rr1;
            var rr3 = new RectangleRecord(0, 0);
            Console.WriteLine(rr1);
            Console.WriteLine(rr1 == rr2);
            Console.WriteLine(rr1 == rr3);
            Console.WriteLine(rr1.GetQuad());
        }
    }
}
