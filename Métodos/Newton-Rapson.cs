using System;
					
public class Program
{
	public static void Main()
	{
            double x, y, z, f1, f2, f3, epsilon = 0.001; //variables, funciones y margen de error en el sistema de ecuaciones.
            double[,] matriz = new double[3, 4]; //matriz jacobiana
            double pivote, factor; //variables del método de eliminación Gaussiana.
            //Valores arbitrarios de las variables, como no aparecen graficamente en Geogebra, se eligieron al azar.
            x = 1;
            y = 2;
            z = 3;
            //declarar las funciones con los valores establecidos previamente.
            f1 = (y * Math.Cos(x + y) - x)-x;
            f2 = (x * Math.Exp(x + z) - y);
            f3 = (x * z) + (y * z) - (x * y);

			while (Math.Abs(f1) > epsilon | Math.Abs(f2) > epsilon | Math.Abs(f3) > epsilon) 
			{
                //----se calculan las variables ya que con cada ciclo cambian.
                f1 = (y * Math.Cos(x + y) - x)-x;
                f2 = (x * Math.Exp(x + z))- y;
                f3 = (x * z) + (y * z) - (x * y);

                //Matriz de Jacobi con los valores sustituidos, la última columna es el resultado de las ecuaciones originales por -1;
                matriz[0, 0] = -(y * Math.Cos(x + y) - x) - 1;
                matriz[0, 1] = (Math.Cos(y + x)) - (y * Math.Sin(y + x));
                matriz[0, 2] = 0;
                matriz[0, 3] = -f1;
                matriz[1, 0] = (x + 1) * (Math.Exp(x + z));
                matriz[1, 1] = -1;
                matriz[1, 2] = x * (Math.Exp(z + x));
                matriz[1, 3] = -f2;
                matriz[2, 0] = z - y;
                matriz[2, 1] = z - x;
                matriz[2, 2] = y + x;
                matriz[2, 3] = -f3;

               for (int reng = 0; reng < 3; reng ++)
                {
                    pivote = matriz[reng, reng];
                    for (int colu = 0; colu < 4; colu ++)
                    {
                        matriz[reng, colu] = matriz[reng, colu] / pivote;
                    }

                    for (int reng_elimi = 0; reng_elimi < 3; reng_elimi ++)
                    {
                        if (reng_elimi != reng)
                        {
                            factor = matriz[reng_elimi, reng];
                            for (int colu_elimi = 0; colu_elimi < 4; colu_elimi = colu_elimi + 1)
                            {
                                matriz[reng_elimi, colu_elimi] = matriz[reng_elimi, colu_elimi]
                                                                 - factor * matriz[reng, colu_elimi];
                            }
                        }
                    }
			   }
                
                //--------------------- Termina la eliminación Gaussiana ---------------------
                // Se suma a las variables los nuevos valores obtenidos y se evaluan en la nueva matriz.
                x = x + matriz[0, 3];
                y = y + matriz[1, 3];
                z = z + matriz[2, 3];
            }
            //Se Imprimen los resultados de la matriz
            Console.WriteLine("El valor final de x es: " + x);
            Console.WriteLine("El valor final de y es: " + y);
			Console.WriteLine("El valor final de z es: " + z);

            Console.ReadLine();
	}
}