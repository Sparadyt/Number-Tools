using System;

public static class Home
{
    static readonly (string name, Action action)[] options =
    {
        ("Addition", Arithmetic.Addition),
        ("Subtraction", Arithmetic.Subtraction),
        ("Multiplication", Arithmetic.Multiplication),
        ("Division", Arithmetic.Division),
    };

    static void Main()
    {
        while (true)
        {
            int choice = Menu();

            if (choice < 1 || choice > options.Length)
            {
                PrintError("Invalid Option", "Please select a valid option.");
                continue;
            }

            options[choice - 1].action();
        }
    }

    static int Menu()
    {
        Console.Clear();
        Console.WriteLine("HOME\n");

        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i].name}");
        }

        Console.Write("\n> ");

        if (!int.TryParse(Console.ReadLine(), out int choice))
            return -1;

        return choice;
    }

    public static void PrintError(string message, string details)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: {message}");
        Console.WriteLine(details);
        Console.ResetColor();
        Console.ReadKey();
    }

    public static int GetBase(string title)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(title);

            //Asking for base
            Console.WriteLine("Enter the base you want to work in (2-10): ");
            string? baseStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(baseStr))
            {
                PrintError("Empty Input", "Please enter a valid base");
                continue;
            }

            if (!int.TryParse(baseStr, out int baseInt))
            {
                PrintError("Invalid Base", "Please enter a valid integer for the base");
                continue;
            }

            if (baseInt < 2 || baseInt > 10)
            {
                PrintError("Base Out of Range", "Please enter a base between 2 and 10");
                continue;
            }

            Console.Clear();
            return baseInt;
        }
    }

    public static int GetInput(int baseInt, string? input1)
    {
        while (true)
        {
            int input;

            Console.Clear();
            Console.WriteLine($"BASE {baseInt}");

            if (input1 != null)
            {
                Console.WriteLine($"First Number: {input1}");
            }
            
            Console.WriteLine("Enter your number: ");
            string? inputStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputStr))
            {
                PrintError("Empty Input", "Please enter a valid number");
                continue;
            }

            else if(!int.TryParse(inputStr, out input))
            {
                PrintError("Invalid Number", "Please enter a valid integer number");
                continue;
            }

            Console.Clear();
            return input;
        }
    }
}