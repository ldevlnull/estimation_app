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
            for(int i = 0; i < x.Length; i ++) {
                x[i] = A + i * STEP;
                y[i] = f(x[i]);
            }

            /** 
             * 
             * Цей код потрібно розкоментувати, коли ви створити клас, 
             * що буде реалізовувати інтерфейс IEstimationMethod.
             * На місце НАЗВА_КЛАСУ потрібно підставити назву класу, що ви створили.
             * Якщо конструктор вашого класу приймає якісь вхідні параметри, наприклад діапазон,
             * то тут їх можна передати. 
             * Якщо завдання виконане правильно, то результат має бути відповідним.
             * В змінній approximated буде лежати функція, яка є результатом апроксимації або інтерполяції.
             * 
             */

            //IEstimationMethod method = new LagrangePolynomial();
            //Func<double, double> estimatedFunction = method.estimate(x, y);
            //for(double var = 1; var < 4; var += 0.01f)
            //{
            //    Console.WriteLine($"f({ var }) = { estimatedFunction(var) }  [{ Math.Abs(estimatedFunction(var) - f(var)) }]");
            //}
        }
    }
}
