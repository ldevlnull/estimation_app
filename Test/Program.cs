using System;
using System.Collections;
using System.Collections.Generic;

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
            for(int i = 0; i < x.Length; i ++) {
                x[i] = A + i * STEP;
                y[i] = f(x[i]);
            }

     

            /*
             * 
             * Щоб відтестувати метод, який ви реалізували,
             * просто додайте екземпляр його класу до масиву methods
             * і можете запускати цей клас.
             * 
             * Після тесту ви побачите результати і середню помилку метода.
             * Якщо вона відносно мала, значить все працює правильно.
             * 
             */

            IEstimationMethod[] methods = {
                new LagrangePolynomial(),
                new Linear_LSM(),
                new NewtonInterpolation()
            };

            Dictionary<IEstimationMethod, double> errors = new Dictionary<IEstimationMethod, double>();

            
            // Параметри для тесту, їх можна поміняти, щоб подивитись, як працює функція. 
            double testingStep = 0.001f; // крок змінної при інтерполюванні
            double testingA = 1; // ліва межа інтерполювання функції
            double testingB = 4; // права межа інтерполювання функції

            foreach (IEstimationMethod method in methods)
            {
                double avg = 0;
                Func<double, double> estimatedFunction = method.estimate(x, y);
                for (double var = testingA; var < testingB; var += testingStep)
                {
                    Console.WriteLine($"f({ var }) = { estimatedFunction(var) }  [{ Math.Abs(estimatedFunction(var) - f(var)) }]");
                    avg += Math.Abs(estimatedFunction(var) - f(var));
                }
                errors.Add(method, avg / ((testingB - testingA) / testingStep));
                Console.WriteLine("\n\n ===== END OF METHOD ===== \n\n");
            }
            foreach(KeyValuePair<IEstimationMethod, double> kvp in errors)
            {
                Console.WriteLine(String.Format("{0, -40}", $"Average error of {kvp.Key}") + $"\t=\t{kvp.Value}");
            }
        }
    }
}
