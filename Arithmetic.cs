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
            
            Console.WriteLine($"{options.Length + 1}. Exit");

            ConsoleKeyInfo key = Console.ReadKey();

            if (!int.TryParse(key.KeyChar.ToString(), out int inputDigit))
            {
                Home.PrintError("Invalid Input", "Please enter a digit");
                continue;
            }


            //+2 because +1 for exit, +1 becase 1 was added to `i`
            if (inputDigit < 1 || inputDigit > options.Length + 1)
            {
                Home.PrintError("Input out of range", $"The input was out of range. Please enter a number from 1 to {options.Length + 1}");
                continue;
            }

            if (inputDigit == options.Length + 1)
            {
                break;
            }

            options[inputDigit - 1].action();
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
            long input1 = GetInput(baseInt, null, null);
            long input2 = GetInput(baseInt, input1, '+');

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
            long input1 = GetInput(baseInt, null, null);
            long input2 = GetInput(baseInt, input1, '-');

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
            long input1 = GetInput(baseInt, null, null);
            long input2 = GetInput(baseInt, input1, '*');

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
            long input1 = GetInput(baseInt, null, null);
            long input2 = GetInput(baseInt, input1, '/');

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
            long input1 = GetInput(baseInt, null, null);
            long input2 = GetInput(baseInt, input1, '%');

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

    public static ConsoleKeyInfo GetAndPrintResult(long input1, long input2, int baseInt, char operation)
    {
        Console.Clear();

        bool skip = false;
        long base10Input1 = Home.ToBase10(input1, baseInt);
        long base10Input2 = Home.ToBase10(input2, baseInt); 
        long base10Result = 0; //Temporary

        //Performing operation
        if (operation == '+')
        {
            base10Result = base10Input1 + base10Input2;
        }

        else if (operation == '-')
        {
            base10Result = base10Input1 - base10Input2;
        }

        else if (operation == '*')
        {
            base10Result = base10Input1 * base10Input2;
        }

        else if (operation == '/')
        {
            if (base10Input2 == 0)
            {
                Home.PrintError("Division By Zero", "The second number cannot be zero in division. Please enter a valid number");
                skip = true;
            }

            else
                base10Result = base10Input1 / base10Input2;
        }

        else if (operation == '%')
        {
            if (base10Input2 == 0)
            {
                Home.PrintError("Division By Zero", "The second number cannot be zero in module. Please enter a valid number");
                skip = true;
            }
            
            else
                base10Result = base10Input1 % base10Input2;
        }

        long result = Home.ToAnyBase(base10Result, baseInt);

        //Printing result
        if (!skip)
        {
            Console.WriteLine($"BASE {baseInt}");
            Console.WriteLine($"First input: {input1}");
            Console.WriteLine($"Second input: {input2}");
            Console.WriteLine($"{input1} {operation} {input2}");
            Console.WriteLine();

            Console.WriteLine($"Result: {result} in base {baseInt}");
            Console.WriteLine($"Result: {base10Result} in decimal");
        }
        
        Console.WriteLine("(Press Esc or E to exit)");
        Console.WriteLine("(Enter B to work with a different base)");
        return Console.ReadKey();
    }

    public static long GetInput(int baseInt, long? input1, char? symbol)
    {
        while (true)
        {
            long input;

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

            else if(!long.TryParse(inputStr, out input))
            {
                Home.PrintError("Invalid Number", "Please enter a valid integer");
                continue;
            }

            Console.Clear();
            return input;
        }
    }
}