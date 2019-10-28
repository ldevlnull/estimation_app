using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Крок і межі генерування вузлів
            const double STEP = 0.1f;
            const double A = 0;
            const double B = 5;

            const int N = (int)((B - A) / STEP); // кількість вузлів згідно з нашого діапазону і кроку
            // Створюємо два масиви для вузлів
            double[] x = new double[N];
            double[] y = new double[N];

            // Функція, яку будемо апроксимувати/інтерполювати для тесту
            Func<double, double> f = x => 2 * Math.Cos(x);

            // Наповнюємо масиви значеннями вузлів для подальшого використання в якості вхідних данних
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = A + i * STEP;
                y[i] = f.Invoke(x[i]);
            }

            IEstimationMethod method = new Linear_LSM();
            Func<double, double> estimatedFunction = method.estimate(x, y);
            for (double var = 0; var < 5; var += 0.05f)
            {
                Console.WriteLine("f(" + var + ")  = " + f.Invoke(var) + 
                    "\t|  fa(" + var + ") = " + estimatedFunction.Invoke(var));
            }
        }
    }
}
