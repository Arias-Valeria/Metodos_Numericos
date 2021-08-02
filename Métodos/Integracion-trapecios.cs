using System;
					
public class Program
{
	public static void Main()
	{
		double base_trap, alt1, alt2, x;
            double area = 0, numPartes = 10000;
            double lim_sup, lim_inf;

            Console.WriteLine("Introduzca el valor del límite inferior: ");
            lim_inf = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca el valor del límite superior: ");
            lim_sup = int.Parse(Console.ReadLine());

            // Se calcula la base de cada trapecio.
            base_trap = (lim_sup - lim_inf) / numPartes;

            x = lim_inf;

            while (x < lim_sup)
            {
                // La funcion original a integrar se evalúa en los diferentes valores de x.
                alt1 = Math.Exp(x*x);
                // se incrementa el valor de x y se calcula la altura 2.
                x = x + base_trap;
                alt2 = Math.Exp(x * x);
                //Sumatoria de todas las áreas.
                area = area + (base_trap * (alt1 + alt2)) / 2;


            }
            Console.WriteLine("PROGRAMA 1.");
            Console.WriteLine("La integral numerica es: " + area);
            Console.ReadLine();
	}
}