using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Problema 1, parte b");
		//Se colocan los arreglos para los valores x, y; tal como se describe en el problema
		double[] x = {-5, -3, -0.7, 0.25, 2.1, 6, 7.46, 19.1, 15.5};
        double[] y = {6, 5.3, 1.53, -2.7, 4, 9.1, 2.2, 3.5, 6.2};
		
		Console.WriteLine();
		Console.WriteLine("(x: " + x[0] + " | " + x[1] + "  | " + x[2] + " | " + x[3] + " | " + x[4] + " | " + x[5] + "   | " +  x[6] + " | " + x[7] + " | " + x[8] + ")");
		Console.WriteLine("(y: " + y[0] + "  | " + y[1] + " | " + y[2] + " | " + y[3] + " | " + y[4] + "   | " + y[5] + " | " +  y[6] + "  | " + y[7] + "  | " + y[8] + " )");
		Console.WriteLine();
		
		//Se coloca un arreglo adicional para aplicar el polinomio de Newton
        double[,] matriz = new double[9,10];
        double pivote, factor;
		//x_0 es el valor del punto intermedio que ya fue anteriormente establecido
        double x_0 = 6.574;
        double y_0 = 0;
		
        //Se utiliza for para calcular los valores mediante el siguiente proceso
        for (int i = 0; i < 9; i = i + 1)
        {
            for (int j = 0; j < 9; j = j + 1)
            {
                matriz[i, j] = Math.Pow(x[i],j);
            }
        }
        for (int i = 0; i < 9; i = i + 1)
        {
            matriz[i, 9] = y[i];
        }       
        //Aplicamos eliminación Gaussiana
        //------------------------------
        for (int reng = 0; reng < 9; reng = reng + 1)
        {
            pivote = matriz[reng, reng];
            for (int colu = 0; colu < 10; colu = colu + 1)
            {
                matriz[reng, colu] = matriz[reng, colu] / pivote;
            }
            for (int reng_elimi = 0; reng_elimi < 9; reng_elimi = reng_elimi + 1)
            {
                if (reng_elimi != reng)
                {
                    factor = matriz[reng_elimi, reng];
                    for (int colu_elimi = 0; colu_elimi < 10; colu_elimi = colu_elimi + 1)
                    {
                        matriz[reng_elimi, colu_elimi] = matriz[reng_elimi, colu_elimi]
                            - factor * matriz[reng, colu_elimi];
                    }
                }
            }
        }
        //------------------------------        
        for (int i = 0; i < 9; i = i + 1)
        {
            y_0 = y_0 + matriz[i, 9]*Math.Pow(x_0,i);
        }
		
        //Sólo queda imprimir el resultado       
        Console.WriteLine("El valor de y en " + x_0 + " es " + y_0);
        Console.ReadLine();
	}
}