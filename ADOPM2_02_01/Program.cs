using System;


namespace ADOPM2_02_01
{
    class Program
    {
		struct RectangleStruct
		{
			public double Width { get; set; }
			public double Height { get; set; }
			public double Diagonal => Math.Sqrt(Width * Width + Height * Height);

			public RectangleStruct(double width, double height)
			{
				Width = width;
				Height = height;
			}
		}
		class RectangleClass
		{
			public double Width { get; set; }
			public double Height { get; set; }
			public double Diagonal => Math.Sqrt(Width * Width + Height * Height);

			public RectangleClass(double width, double height)
			{
				Width = width;
				Height = height;
			}
		}

		static void Main(string[] args)
		{
			const long arraySize = 10_000_000;
			long size1 = GC.GetTotalMemory(true);

			//Roughly 1 600 000 bytes
			RectangleStruct[] arrayStruct = new RectangleStruct[10_000_000];

			long size2 = GC.GetTotalMemory(true);
			Console.WriteLine($"Rough size of {nameof(arrayStruct)} immediatly allocated estimate: {2 * sizeof(double) * arraySize:N0} bytes");
			Console.WriteLine($"Rough size of {nameof(arrayStruct)} immediatly allocated by GC:  {size2-size1:N0} bytes");
			Console.WriteLine();

			//Roughly 800 000 bytes
			RectangleClass[] arrayClass = new RectangleClass[10_000_000];
			long size3 = GC.GetTotalMemory(true);
			
			Console.WriteLine($"Rough size of {nameof(arrayClass)} immediatly allocated estimate: {sizeof(long) * arraySize:N0} bytes");
			Console.WriteLine($"Rough size of {nameof(arrayClass)} immediatly allocated by GC:  {size3 - size2:N0} bytes");
		}
	}
}
