using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Problema 1. y' = (3x + 5y) / 2");
            //Declarar las variables a emplear.
            double y, x, k1, k2, k3, k4, delta;

            //Inicializar los valores de X y Y
            x = 0;
            y = 1;

            //Se define el incremento de delta.
            delta = 0.2;

            //Se crea el bucle para la repetición de los pasos.
            while (x < 5)
            {
                //K1 es la ecuación evaluada en los puntos originales.
                k1 = (3 * x + 5 * y) / 2;
                
				//K2 es la ecuación evaluada con la mitad de d(x)
                k2 = (3 * (x + delta / 2) + 5 * (y + (delta / 2 * k1))) / 2;
                
				//K3 es la ecuación la mitad de delta de x.
                k3 = (3 * (x + (delta / 2)) + 5 * (y + (delta / 2 * k2))) / 2;
                
				//K4 es la ecuación con el incremento de delta.
                k4 = (3 * (x + delta) + 5 * (y + (delta * k3))) / 2;
                
				//Se calcula el valor de y.
                y = y + (k1 + k2 + k3 + k4) / 6 * delta;
                
				//Se incrementa el valor de x.
                x = x + delta;
            }
            Console.WriteLine("Cuando x es: " + x + ", f(x) vale: " + y);
            Console.ReadLine();
	}
}