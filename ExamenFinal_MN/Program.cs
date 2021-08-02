using System;
using System.Linq;

namespace ExamenFinal_MN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Defina la cantidad de incremento (paso de búsqueda): ");
            double paso = double.Parse(Console.ReadLine());
            
            //Primer ciclo for para recorrer los valores de x
            for (double x = 0; x < (2*Math.PI); x = x + paso)
            {
                double ec1 = 2.5 * Math.Sin(3 * x) + 8;
                double ec2 = 3 * Math.Cos(2 * x) + 5;
                //Condición con la ecuación(es).
                if (2.5 * Math.Sin(3 * x) + 8 == 3 * Math.Cos(2 * x) + 5)
                {
                    Console.WriteLine("El angulo es: " + x);
                    Console.WriteLine("Cuando la altura 1 es: " + ec1 + " y la altura 2 es: " + ec2);
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
