using System;

namespace ADOPM2_02_06
{
    public class StackInt
    {
        int position = 0;
        int[] data = new int[100];
        public void Push(int value)
        {
            data[position] = value;
            position++;
        }
        public int Pop()
        {
            --position;
            return data[position];
        }
    }
    public class StackString
    {
        int position = 0;
        string[] data = new string[100];

        public void Push(string value)
        {
            data[position] = value;
            position++;
        }
        public string Pop()
        {
            --position;
            return data[position];
        }
    }
    public class Stack<T>
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
            return data[position];
        }
        public T Peek()
        {
            return data[position-1];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StackInt myStackInt = new StackInt();
            myStackInt.Push(25);
            myStackInt.Push(350);

            Console.WriteLine(myStackInt.Pop()); //350
            Console.WriteLine(myStackInt.Pop()); //25

            StackString myStackString = new StackString();
            myStackString.Push("Hello 25");
            myStackString.Push("Hello 350");

            Console.WriteLine(myStackString.Pop()); //Hello 350
            Console.WriteLine(myStackString.Pop()); //Hello 25

            Console.WriteLine();
            var stack = new Stack<int>();
            stack.Push(25);
            stack.Push(350);
            Console.WriteLine(stack.Pop()); // 350
            Console.WriteLine(stack.Pop()); // 25

            var stack1 = new Stack<string>();
            stack1.Push("Hello 25");
            stack1.Push("Hello 350");
            Console.WriteLine(stack1.Pop()); //Hello 350
            Console.WriteLine(stack1.Pop()); //Hello 25

            Console.WriteLine("Tuple demo");
            var stack2 = new Stack<(int,string)>();
            stack2.Push((475, "Hello 475"));
            Console.WriteLine(stack2.Pop());


            Console.WriteLine();
            DoDoublePush(stack1);
            Console.WriteLine(stack1.Pop());
            Console.WriteLine(stack1.Pop());

            Console.WriteLine();
            DoDoublePush<int>(stack, 67, 75);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            Console.WriteLine();
            DoDoublePush<string>(stack1, "Number uno", "Numero dous");
            Console.WriteLine(stack1.Pop());
            Console.WriteLine(stack1.Pop());

            Console.WriteLine();
            DoDoublePush<(int, string)>(stack2, (4, "Four"), (5, "Five"));

                 
            bool[] boolArray = { true, true, true, false, false, false };
            
            PrintFirstElement<bool>(boolArray);
            
        }

        //Methods using a closed Generic type
        static int DoDoublePush(Stack<string> myStack)
        {
            myStack.Push("First push");
            myStack.Push("Second push");

            return 2;
        }
        static int DoDoublePush(Stack<(int,string)> myStack)
        {
            myStack.Push((1,"First push"));
            myStack.Push((2,"Second push"));

            return 2;
        }

        //Methods using open Generic types
        static int DoDoublePush<T>(Stack<T> myStack, T firstElement, T secondElement)
        {
            myStack.Push(firstElement);
            myStack.Push(secondElement);

            return 2;
        }

        //Method using an open Generic type as an array parameter
        static void PrintFirstElement<T>(T[] myArray)
        {
            foreach (var item in myArray)
            {
                Console.WriteLine(item);
            }
        }
    }

    //Exercises
    //1.    Create an array of type int[] and initializa it with some value.
    //      Create a Method that takes int[] as a parameter, loops through the array and print out the values
    //      Create another array of string[] and a method that loops through the array and print out the values. 
    //      Notice the small difference in the Methods

    //2.    Using DRY, make one single method which is using a Generic Parameter T that prints out both arrays
}
