using System;

namespace ADOPM2_02_07
{
    public class Stack<T> where T: class, new()
    {
        int position = 0;
        T[] data = new T[100];

        public void Push(T value)
        {
            data[position] = value;
            position++;
        }
        public T Pop()
        {
            --position;
            var retObj = data[position];
            data[position] = null;
            return retObj;
        }
        public T Peek()
        {
            return data[position - 1];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
                       var stack = new Stack<int>();
                       stack.Push(5);
                       stack.Push(10);
                       Console.WriteLine(stack.Pop()); // 10
                       Console.WriteLine(stack.Pop()); // 5

                       //var stack1 = new Stack<string>();  // Compiler contraint error
                       //stack1.Push("First Element");
                       //stack1.Push("Second Element");
                       //Console.WriteLine(stack1.Pop());
                       //Console.WriteLine(stack1.Pop());

                       var stack1 = new Stack<float>();
                       stack1.Push(1.234F);
                       stack1.Push(5.678F);
                       Console.WriteLine(stack1.Pop()); // 5.678
                       Console.WriteLine(stack1.Pop()); // 1.234
           */
            var stack = new Stack<Chef>();
            stack.Push(new SwedishChef { Name = "Erik" });
            stack.Push(new ItalianChef { Name = "Mauro" });
            stack.Push(new FrenchChef { Name = "Pierre" });

            Console.WriteLine(stack.Peek());    // Pierre
            Console.WriteLine(stack.Peek());    // Pierre
            Console.WriteLine(stack.Pop());     // Pierre
            Console.WriteLine(stack.Pop());     // Mauro

            string[] stringArray = new string[3];

            Stack<Chef>[] multiCultureChefs = new Stack<Chef>[3];

            //Swedish Chefs
            multiCultureChefs[0] = new Stack<Chef>();
            multiCultureChefs[0].Push(new SwedishChef { Name = "Karl" });
            multiCultureChefs[0].Push(new SwedishChef { Name = "Erik" });

            //French Chefs
            multiCultureChefs[1] = new Stack<Chef>();
            multiCultureChefs[1].Push(new FrenchChef { Name = "Pierre"});
            multiCultureChefs[1].Push(new FrenchChef { Name = "Francois" });
            multiCultureChefs[1].Push(new FrenchChef { Name = "Herve" });

            //Mixed Italian and Swedish Chefs
            multiCultureChefs[2] = new Stack<Chef>();
            multiCultureChefs[2].Push(new SwedishChef { Name = "Per" });
            multiCultureChefs[2].Push(new ItalianChef { Name = "Vincenzo" });

            Console.WriteLine();
            foreach (var item in multiCultureChefs)
            {
                Console.WriteLine(item.Peek());
            }

            Console.WriteLine();
            for (int i = 0; i < multiCultureChefs.Length; i++)
            {
                Console.WriteLine(multiCultureChefs[i].Peek());
            }
        }
    }

    //Exercises
    //1.    Modify above code to allow only T as a type of class.
    //2.    Create your own instance of class type (For example Chef). Use them to close Stack<T>. Fill it and Test and printout result showing Pop() result
    //3.    Add a constraint that T must have a parameterless construction. Test by declaring only a constructor with parameter.
    //4.    Create an array of Stack<Chef> which contains 3 Stacks. Initiate each stack with instances of SwedishChef, ItalianChef, FrenchChef.
    //5.    Printout the top element of each Stack<Chef> by looping through the array of Stack<Chef>
}
