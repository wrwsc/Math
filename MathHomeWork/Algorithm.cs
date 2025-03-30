namespace MathHomeWork;

internal static class Algorithm
{
    internal static void Print(int a, int b, int m)
    {
        // НОД
        var gcd = Gcd(a, m, out var x1, out var y1);
        Console.WriteLine($"НОД({a}, {m}) = {gcd}");

        // Делимость b на НОД
        if (b % gcd != 0)
        {
            Console.WriteLine($"b не делится на НОД.");
            return;
        }

        // Сокращаем уравнение
        var first = a / gcd;
        var second = b / gcd;
        var mod = m / gcd;
        Console.WriteLine($"Сокращенное уравнение: {first}x = {second} (mod {mod})");

        // Обратный элемент
        var r = (Reverse(first, mod) * second) % mod;
        if (r < 0) r += mod;
        Console.WriteLine($"P(n-1): {r} (mod {mod})");

        // Общее решение
        DisplayAllSolutions(gcd, r, mod);
    }

    private static int Gcd(int a, int b, out int x, out int y)
    {
        if (b == 0)
        {
            x = 1; 
            y = 0;
            return a;
        }
        var gcd = Gcd(b, a % b, out var x1, out var y1);
        x = y1;
        y = x1 - (a / b) * y1;
        return gcd;
    }
    
    private static int Reverse(int a, int m)
    {
        var gcd = Gcd(a, m, out var x, out _);
        if (gcd != 1) Console.WriteLine("Обратного элемента нет");
        return (x % m + m) % m;
    }
    
    private static void DisplayAllSolutions(int gcd, int x0, int m1)
    {
        Console.WriteLine("Все решения: ");
        var temp = 0;
        Console.WriteLine("  ~");
        for (var k = 0; k < gcd; k++)
        {
            temp++;
            var xk = x0 + k * m1;
            if (k == 3)
            {
                Console.WriteLine($"< x{k} = {xk}");
            }
            else
                Console.WriteLine($" |x{k} = {xk}");
        }
        Console.WriteLine("  ~");
        Console.WriteLine($"Кол-во решений: {temp}");
    }
}