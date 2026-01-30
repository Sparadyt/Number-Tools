using System;

public static class Arithmetic
{
    public static void Addition()
    {
        while(true)
        {
            Console.Clear();
            int baseInt = Home.GetBase("ADDITION");
            Console.ReadKey();
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