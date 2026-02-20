using System;

public static class Other
{
    public static void Changebase()
    {
        while (true)
        {
            //Input Stuff
            int fromBase = Home.GetBase("CHANGE BASE: from");
            int toBase = Home.GetBase($"CHANGE BASE: to\nFrom: {fromBase}");
            long input = Arithmetic.GetInput(fromBase, null, null);

            long base10 = Home.ToBase10(input, fromBase);
            long result = base10;

            if (toBase != 10)
                result = Home.ToAnyBase(base10, toBase);

            else if (toBase == fromBase)
                result = input;

            //Output
            Console.WriteLine($"From Base: {fromBase}");
            Console.WriteLine($"To Base: {toBase}");
            Console.WriteLine($"Result in base {toBase}: {result}");
            Console.WriteLine($"Result in decimal: {base10}");
            Console.ReadKey();
        }
    }
}