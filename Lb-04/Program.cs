using System;

namespace Lb_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var finder = new LinearMaxFinder();
            finder.Execute((x, y) => x + y);

            Console.ReadLine();
        }
    }

    class LinearMaxFinder
    {
        public void Execute(Func<double, double, double> func)
        {
            int n = 4;
            double x;
            double y;
            double x1 = 0;
            double x2 = 0;
            double max = double.MinValue;
            double[,] a = new double[n, 2];
            double[] b = new double[n];


            a[0, 0] = 7; a[0, 1] = 5; b[0] = 40;
            a[1, 0] = -5; a[1, 1] = 4; b[1] = 6;
            a[2, 0] = 1; a[2, 1] = 2; b[2] = 8;
            a[3, 0] = 1; a[3, 1] = 0; b[3] = 3;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (Math.Abs(a[i, 0] * a[j, 1] - a[i, 1] * a[j, 0]) > 0.001)
                    {
                        x = (b[i] * a[j, 1] - a[i, 1] * b[j]) / (a[i, 0] * a[j, 1] - a[i, 1] * a[j, 0]);
                        y = (a[i, 0] * b[j] - b[i] * a[j, 0]) / (a[i, 0] * a[j, 1] - a[i, 1] * a[j, 0]);

                        int t = 1;
                        Console.WriteLine($"{x} = {y} {i} {j}");
                        for (int k = 0; k < n; k++)
                            switch (k)
                            {
                                case 1: if (a[k, 0] * x + a[k, 1] * y < b[k]) t = 0; break;
                                case 2: if (a[k, 0] * x + a[k, 1] * y < b[k]) t = 0; break;
                                case 3: if (a[k, 0] * x + a[k, 1] * y > b[k]) t = 0; break;
                                case 4: if (a[k, 0] * x + a[k, 1] * y == b[k]) t = 0; break;
                            }
                        Console.WriteLine(t);
                        if (t == 0 && func(x, y) > max)
                        {
                            max = func(x, y);
                            x1 = x;
                            x2 = y;
                        }
                    }

            Console.WriteLine($"x1 = {x1}; x2 = {x2}; max = {max}");

        }


    }
}
