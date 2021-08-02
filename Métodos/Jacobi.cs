using System;
					
public class Program
{
	public static void Main()
	{
		//Variables de Entrada 
		    double x, y, f1, f2, epsilon = 0.001; //epsilon es el margen, muy cercano a 0.
            
		//Variables empleadas en el método de Gauss-Jordan
			double pivote, factor;
		
		//La matriz declarada es en función del tipo de sistema, 3x3, 2x3, 3x2 etc.
            double[,] matriz = new double[2,3];

		//Valores inciales, pueden ser cualquiera.
            x = 1;
            y = -1.7;
		
		//Las ecuaciones son evaluadas con los valores antes asignados.
            f1 = x * x + y * y - 4;
            f2 = Math.Exp(x) + y - 1;

		  //Mientras las ecuaciones iniciaes sean mayores a epsilo el ciclo continua
            while (Math.Abs(f1) > epsilon | Math.Abs(f2) > epsilon) 
            {
				//En cada ciclo se calculan las ecuaciones ya que cambian.
				f1 = x * x + y * y - 4;
                f2 = Math.Exp(x) + y - 1;
                
				//Matriz jacobianan con la columna aumentada multiplicada por -1
				matriz[0, 0] = 2 * x;
                matriz[0, 1] = 2 * y;
                matriz[0, 2] = -f1;
                matriz[1, 0] = Math.Exp(x);
                matriz[1, 1] = 1;
                matriz[1, 2] = -f2;

                //Eliminación Gaussiana 
                for (int reng = 0; reng < 2; reng = reng + 1)
                {
                    pivote = matriz[reng, reng];
                    for (int colu = 0; colu < 3; colu = colu + 1)
                    {
                        matriz[reng, colu] = matriz[reng, colu] / pivote;
                    }
                    for (int reng_elimi = 0; reng_elimi < 2; reng_elimi = reng_elimi + 1)
                    {
                        if (reng_elimi != reng)
                        {
                            factor = matriz[reng_elimi, reng];
                            for (int colu_elimi = 0; colu_elimi < 3;
                                colu_elimi = colu_elimi + 1)
                            {
                                matriz[reng_elimi, colu_elimi] = matriz[reng_elimi,
                                   colu_elimi] - factor * matriz[reng, colu_elimi];
                            }
                        }
                    }
                }
                //------------------------------ Fin de la eliminación Gaussiana ------------------------------
                
				//Se suma a las variables el incremento y el valor de cada columna aumentada.
                x = x + matriz[0, 2];
                y = y + matriz[1, 2];

            }
			//Se imprimen los resultados.
            Console.WriteLine("El valor final de x es: " + x);
            Console.WriteLine("El valor final de y es: " + y);

            Console.ReadLine();
	}
}