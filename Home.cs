using System;

public static class Home
{
    static readonly (string name, Action action)[] options =
    {
        ("Arithmetic+", Arithmetic.HOME),
        ("Change Base", Other.Changebase)
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

    public static long ToBase10(long input, int fromBase)
    {
        long result = 0;

        foreach (char c in input.ToString())
        {
            if (!char.IsDigit(c))
            {
                PrintError("Invalid input", "Please enter a number");
                break;
            }

            int digitValue = c - '0';

            if (digitValue >= fromBase)
            {
                PrintError("Invalid Input", $"Unrecnogised symbol '{c}' for base {fromBase}");
                break;
            }

            result = result * fromBase + digitValue;
        }

        return result;
    }

    public static long ToAnyBase(long input, long toBase)
    {
        //Input base needs to be base 10

        if (toBase < 2 || toBase > 10)
        {
            PrintError("Invalid Base", "The output base was either, less than 2 or more than 10");
            return 0;
        }

        if (input == 0)
        {
            return 0;
        }

        string result = "";

        while (input > 0)
        {
            long remainder = input % toBase;
            result = remainder + result;
            input /= toBase;
        }

        return Convert.ToInt64(result);
    }
}