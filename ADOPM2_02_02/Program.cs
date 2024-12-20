﻿using System;

namespace ADOPM2_02_02
{
    class Program
    {
		readonly struct immutableRectangleStruct
		{
			public readonly double Width { get; init; }
			public readonly double Height { get; init; }

			public static bool operator ==(immutableRectangleStruct r1, immutableRectangleStruct r2) => Equals(r1, r2);
			public static bool operator !=(immutableRectangleStruct r1, immutableRectangleStruct r2) => !Equals(r1, r2);

			public override string ToString() =>
				$"{nameof(immutableRectangleStruct)} {{ {nameof(Width)}={Width}, {nameof(Height)}={Height} }}";
			public immutableRectangleStruct(double width, double height)
			{ 
				(Width, Height) = (width, height);
			}
			public immutableRectangleStruct SetWidth(double Width)
			{
				var result = new immutableRectangleStruct { Height = this.Height, Width = Width  };
				return result;
			}
			public void Deconstruct(out double width, out double height)
			{
				width = Width;
				height = Height;
			}
		}

		class immutableRectangleClass : IEquatable<immutableRectangleClass>	
		{
			public double Width { get; init; }
			public double Height { get; init; }

			public bool Equals(immutableRectangleClass other) =>
						(Width, Height) == (other.Width, other.Height);

			public static bool Equals(immutableRectangleClass r1, immutableRectangleClass r2) => r1.Equals(r2);	
            public static bool operator ==(immutableRectangleClass r1, immutableRectangleClass r2) => Equals(r1, r2);
			public static bool operator !=(immutableRectangleClass r1, immutableRectangleClass r2) => !Equals(r1, r2);
			public override string ToString() => 
				$"{nameof(immutableRectangleClass)} {{ {nameof(Width)}={Width}, {nameof(Height)}={Height} }}";

            public immutableRectangleClass SetWidth(double Width)
            {
                var result = new immutableRectangleClass { Height = this.Height, Width = Width };
                return result;
            }

            public immutableRectangleClass() { }
			public immutableRectangleClass(double width, double height) => (Width, Height) = (width, height);
			
			//Copy Constructor
			public immutableRectangleClass(immutableRectangleClass original)
			{
				Width = original.Width;
				Height = original.Height;
			}

			public void Deconstruct(out double width, out double height)
			{
				width = Width;
				height = Height;
			}
		}
		static void Main(string[] args)
        {
			
			var irs1 = new immutableRectangleStruct { Width = 400, Height = 100 };
			var irs2 = irs1;
			var irs3 = irs1.SetWidth(800);
            Console.WriteLine(irs1);
            Console.WriteLine(irs2);
            Console.WriteLine(irs3);

            Console.WriteLine(irs1);
            Console.WriteLine(irs1 == irs2);
            Console.WriteLine(irs1 == irs3);

            var irc1 = new immutableRectangleClass { Width = 400, Height = 100 };
            var irc2 = new immutableRectangleClass(irc1);
			var irc3 = irc1.SetWidth(800);

            Console.WriteLine(irc1);
			Console.WriteLine(irc2);
			Console.WriteLine(irc3);
	
			Console.WriteLine(irc1);
			Console.WriteLine(irc1 == irc2);
			Console.WriteLine(irc1 == irc3);
		}
	}
}

