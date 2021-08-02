using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Problema 1, parte a");
		//Se colocan los arreglos para los valores x, y; tal como se describe en el problema
		double[] x = {-5, -3, -0.7, 0.25, 2.1, 6, 7.46, 19.1, 15.5};
        double[] y = {6, 5.3, 1.53, -2.7, 4, 9.1, 2.2, 3.5, 6.2};
		
		Console.WriteLine();
		Console.WriteLine("(x: " + x[0] + " | " + x[1] + "  | " + x[2] + " | " + x[3] + " | " + x[4] + " | " + x[5] + "   | " +  x[6] + " | " + x[7] + " | " + x[8] + ")");
		Console.WriteLine("(y: " + y[0] + "  | " + y[1] + " | " + y[2] + " | " + y[3] + " | " + y[4] + "   | " + y[5] + " | " +  y[6] + "  | " + y[7] + "  | " + y[8] + " )");
		Console.WriteLine();
		
		//Se coloca un arreglo adicional para aplicar los polinomios de Lagrange 
        double[] l = new double[9];
        //x_0 es el valor del punto intermedio que ya fue anteriormente establecido
		double x_0 = 6.574;
        double fx = 0;
        //Se utiliza for para calcular el valor de fx mediante el siguiente proceso
        for (int i = 0; i < 9; i = i + 1)
        {
            l[i]=1;
            for (int j = 0; j < 9; j = j + 1)
            {
                if (i != j)
                {
                    // Se crean los polinómios, que corresponden a xi 
					l[i] = l[i] * ((x_0 - x[j]) / (x[i] - x[j]));
                }
            }
			//Esta es la ecuacion que se utiliza para obtener la funcion (y) de acuerdo a lo obtenido por medio de los polinomios de Lagrange
            fx= fx + l[i] * y[i];
        }
        //Sólo queda imprimir el resultado
		Console.WriteLine("El valor de y en " + x_0 + " es " + fx);
        Console.ReadLine();
	}
}