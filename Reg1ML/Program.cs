// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;

namespace Reg1ML
{
    class Program
    {
       
        static void Main(string[] args)
        {
            float[] X = { 1, 1, 2, 3, 4 };
            float[] y = { 2, 3, 4, 5, 5 };
            

            var linearRegressor = new LinearRegressor();
            linearRegressor.Fit(X, y);

            var predictions = linearRegressor.Predict(X);

            Console.WriteLine("Predictions:");
            Console.WriteLine($"{string.Join(", ", predictions.Select(p => p.ToString()))}");

            Console.WriteLine("Actual Value:");
            Console.WriteLine($"{string.Join(", ", y.Select(p => p.ToString()))}");
            //Console.WriteLine($"{_b0}");
            Console.ReadLine();
        }
        public class LinearRegressor
        {
            public float _b0;
            public float _b1;

            public LinearRegressor()
            {
                _b0 = 0;
                _b1 = 0;
            }

            /// <summary>
            /// Train Linear Regression algoritm.
            /// </summary>
            /// <param name="X">Input Data</param>
            /// <param name="y">Output Data</param>
            public void Fit(float[] X, float[] y)
            {
                var ssxy = X.Zip(y, (a, b) => a * b).Sum() - X.Length * X.Average() * y.Average();
                var ssxx = X.Zip(X, (a, b) => a * b).Sum() - X.Length * X.Average() * X.Average();

                _b1 = ssxy / ssxx;
                _b0 = y.Average() - _b1 * X.Average();
               
            }

            /// <summary>
            /// Predict new values.
            /// </summary>
            /// <param name="x">Input Data</param>
            /// <returns>Predictions from the trained algoritm.</returns>
            public float[] Predict(float[] x)
            {
                System.Console.WriteLine($" {_b0}, {_b1} ");
                return x.Select(i => _b0 + i * _b1).ToArray();
                
            }
            
        }
    }
}

