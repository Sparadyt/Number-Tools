using System;

public static class Arithmetic
{
    static readonly (string name, Action action)[] options =
    {
        ("Addition", Addition),
        ("Subtraction", Subtraction),
        ("Multiplication", Multiplication),
        ("Division", Division),
        ("Module", Module)
    };
    public static void HOME()
    {
        while(true)
        {
            Console.Clear();

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i].name}");
            }
            
            Console.WriteLine($"{options.Length + 2}. Exit");

            ConsoleKeyInfo key = Console.ReadKey();

            if (!Char.IsDigit(key.KeyChar))
            {
                Home.PrintError("Invalid Input", "Please enter a digit");
                continue;
            }

            int inputDigit = Convert.ToInt32(key.KeyChar);

            //+2 because +1 for exit, +1 becase 1 was added to `i`
            if (inputDigit < 1 || inputDigit > options.Length + 2)
            {
                Home.PrintError("Input out of range", $"The input was out of range. Please enter a number from 1 to {options.Length + 2}");
                continue;
            }

            if (inputDigit == options.Length + 2)
            {
                continue;
            }

            options[inputDigit].action();
        }
    }
    static void Addition()
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
            string input1 = GetInput(baseInt, null, null).ToString();
            string input2 = GetInput(baseInt, input1, '+').ToString();

            //Printing base and inputs
            Console.WriteLine($"BASE {baseInt}");
            Console.WriteLine($"First Number: {input1}");
            Console.WriteLine($"Second Number: {input2}");
            ConsoleKeyInfo key = GetAndPrintResult(input1, input2, baseInt, '+');

            //Geting end result
            if (key.Key == ConsoleKey.Escape || key.KeyChar == 'e' || key.KeyChar == 'E')
            {
                break;
            }

            else if (key.KeyChar == 'b' || key.KeyChar == 'B')
            {
                newBase = true;
            }

            repeated++;
        }
    }

    static void Subtraction()
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
                baseInt = Home.GetBase("SUBTRACTION");
                newBase = false;
            }

            //Getting both inputs
            string input1 = GetInput(baseInt, null, null).ToString();
            string input2 = GetInput(baseInt, input1, '-').ToString();

            //Printing base and inputs
            Console.WriteLine($"BASE {baseInt}");
            Console.WriteLine($"First Number: {input1}");
            Console.WriteLine($"Second Number: {input2}");
            ConsoleKeyInfo key = GetAndPrintResult(input1, input2, baseInt, '-');

            //Geting end result
            if (key.Key == ConsoleKey.Escape || key.KeyChar == 'e' || key.KeyChar == 'E')
            {
                break;
            }

            else if (key.KeyChar == 'b' || key.KeyChar == 'B')
            {
                newBase = true;
            }

            repeated++;
        }
    }

    static void Multiplication()
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
                baseInt = Home.GetBase("MULTIPLICATION");
                newBase = false;
            }

            //Getting both inputs
            string input1 = GetInput(baseInt, null, null).ToString();
            string input2 = GetInput(baseInt, input1, '*').ToString();

            //Printing base and inputs
            Console.WriteLine($"BASE {baseInt}");
            Console.WriteLine($"First Number: {input1}");
            Console.WriteLine($"Second Number: {input2}");
            ConsoleKeyInfo key = GetAndPrintResult(input1, input2, baseInt, '*');

            //Geting end result
            if (key.Key == ConsoleKey.Escape || key.KeyChar == 'e' || key.KeyChar == 'E')
            {
                break;
            }

            else if (key.KeyChar == 'b' || key.KeyChar == 'B')
            {
                newBase = true;
            }

            repeated++;
        }
    }

    static void Division()
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
                baseInt = Home.GetBase("DIVISION");
                newBase = false;
            }

            //Getting both inputs
            string input1 = GetInput(baseInt, null, null).ToString();
            string input2 = GetInput(baseInt, input1, '/').ToString();

            //Printing base and inputs
            Console.WriteLine($"BASE {baseInt}");
            Console.WriteLine($"First Number: {input1}");
            Console.WriteLine($"Second Number: {input2}");
            ConsoleKeyInfo key = GetAndPrintResult(input1, input2, baseInt, '/');

            //Geting end result
            if (key.Key == ConsoleKey.Escape || key.KeyChar == 'e' || key.KeyChar == 'E')
            {
                break;
            }

            else if (key.KeyChar == 'b' || key.KeyChar == 'B')
            {
                newBase = true;
            }

            repeated++;
        }
    }
    
    static void Module()
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
                baseInt = Home.GetBase("MODULE");
                newBase = false;
            }

            //Getting both inputs
            string input1 = GetInput(baseInt, null, null).ToString();
            string input2 = GetInput(baseInt, input1, '%').ToString();

            //Printing base and inputs
            Console.WriteLine($"BASE {baseInt}");
            Console.WriteLine($"First Number: {input1}");
            Console.WriteLine($"Second Number: {input2}");
            ConsoleKeyInfo key = GetAndPrintResult(input1, input2, baseInt, '%');

            //Geting end result
            if (key.Key == ConsoleKey.Escape || key.KeyChar == 'e' || key.KeyChar == 'E')
            {
                break;
            }

            else if (key.KeyChar == 'b' || key.KeyChar == 'B')
            {
                newBase = true;
            }

            repeated++;
        }
    }

    public static ConsoleKeyInfo GetAndPrintResult(string input1, string input2, int baseInt, char operation)
    {
        Console.Clear();

        int preResult = 0; //Temporary

        //Performing operation
        if (operation == '+')
        {
            preResult = Convert.ToInt32(input1, baseInt) + Convert.ToInt32(input2, baseInt);
        }

        else if (operation == '-')
        {
            preResult = Convert.ToInt32(input1, baseInt) - Convert.ToInt32(input2, baseInt);
        }

        else if (operation == '*')
        {
            preResult = Convert.ToInt32(input1, baseInt) * Convert.ToInt32(input2, baseInt);
        }

        else if (operation == '/')
        {
            preResult = Convert.ToInt32(input1, baseInt) / Convert.ToInt32(input2, baseInt);
        }

        else if (operation == '%')
        {
            preResult = Convert.ToInt32(input1, baseInt) % Convert.ToInt32(input2, baseInt);
        }

        //Printing result
        string result = Convert.ToString(preResult, baseInt);

        Console.WriteLine($"BASE {baseInt}");
        Console.WriteLine($"First input: {input1}");
        Console.WriteLine($"Second input: {input2}");
        Console.WriteLine($"{input1} {operation} {input2}");
        Console.WriteLine();

        Console.WriteLine($"Result: {result} in base {baseInt}");
        Console.WriteLine($"Result: {Convert.ToInt32(result, 10)} in decimal");
        Console.WriteLine("(Press Esc or E to exit)");
        Console.WriteLine("(Enter B to work with a different base)");
        return Console.ReadKey();
    }

    public static int GetInput(int baseInt, string? input1, char? symbol)
    {
        while (true)
        {
            int input;

            Console.Clear();
            Console.WriteLine($"BASE {baseInt}");

            if (input1 != null)
            {
                Console.Write($"{input1} {symbol} ");
            }
            
            else
            {
                Console.WriteLine("Enter your number: ");
            }

            string? inputStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputStr))
            {
                Home.PrintError("Empty Input", "Please enter a valid integer");
                continue;
            }

            else if(!int.TryParse(inputStr, out input))
            {
                Home.PrintError("Invalid Number", "Please enter a valid integer");
                continue;
            }

            Console.Clear();
            return input;
        }
    }
}