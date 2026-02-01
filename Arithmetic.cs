using System;

public static class Arithmetic
{
    public static void Addition()
    {
        bool newBase = false;
        int repeated = 0;
        int baseInt = 0; //Value gets changed immediately

        while(true)
        {
            Console.Clear();

            //Getting base if first time or requested
            if (repeated == 0 || newBase)
            {
                baseInt = Home.GetBase("ADDITION");
                newBase = false;
            }

            //Getting both inputs
            string input1 = Home.GetInput(baseInt, null).ToString();
            string input2 = Home.GetInput(baseInt, input1).ToString();

            //Printing base and inputs
            Console.WriteLine($"BASE {baseInt}");
            Console.WriteLine($"First Number: {input1}");
            Console.WriteLine($"Second Number: {input2}");

            //Calculating and printing result
            int sum = Convert.ToInt32(input1, baseInt) + Convert.ToInt32(input2, baseInt);
            string result = Convert.ToString(sum, baseInt);
            Console.WriteLine($"Result: {result} in base {baseInt}");
            Console.WriteLine($"Result: {sum,10} in decimal");
            Console.WriteLine("(Press Esc or E to exit)");
            Console.WriteLine("(Enter B to work with a different base)");

            repeated++;

            //Waiting for exit input
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape || key.KeyChar == 'e' || key.KeyChar == 'E')
            {
                break;
            }

            else if (key.KeyChar == 'b' || key.KeyChar == 'B')
            {
                newBase = true;
            }
        }
    }

    public static void Subtraction()
    {
        Console.Clear();
        int baseInt = Home.GetBase("SUBTRACTION");
        Console.ReadKey();
    }

    public static void Multiplication()
    {
        Console.Clear();
        int baseInt = Home.GetBase("MULTIPLICATION");
        Console.ReadKey();
    }

    public static void Division()
    {
        Console.Clear();
        int baseInt = Home.GetBase("DIVISION");
        Console.ReadKey();
    }
}