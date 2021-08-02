using System;
					
public class Program
{
	public static void Main()
	{
		//Definir la matriz y las variables a emplear.
            double[,] matriz = new double[3, 4];
            double pivote;
            double factor;

            // Ciclos for para ingresar los datos de la matriz por consola.
            Console.WriteLine("Dame la matriz");
            for (int ren = 0; ren < 3; ren++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.WriteLine("Ingresa la posición [" + ren + "," + col + "]");
                    matriz[ren, col] = double.Parse(Console.ReadLine());
                }

            }
            
			// Proceso de Gauss y la eliminación Gaussiana.
            for (int ren = 0; ren < 3; ren++)
            {
                pivote = matriz[ren, ren];

                for (int col = 0; col < 4; col++)
                {
                    // Se debe dividir la fila entre el valor del pivote.
                   matriz[ren, col] = matriz[ren, col] / pivote;
                }
                //Se eliminan los elementos situados en la misma columna donde está el pivote.
                //A continuación, se elige el renglón
                for (int reng_elimi = 0; reng_elimi < 3; reng_elimi++)
                {
                    if (reng_elimi != ren)
                    {
                        //Se elige el factor que va a multplicar el renglón principal y así eliminar el elemento.
                        factor = matriz[reng_elimi, ren];

                        //Se resta el renglón principal a el renglón que se va a eliminar.
                        for (int colu_elimi = 0; colu_elimi < 4; colu_elimi++)
                        {
                            matriz[reng_elimi, colu_elimi]
                                = matriz[reng_elimi, colu_elimi] - factor
                                * matriz[ren, colu_elimi];
                        }
                    }
                }

            }
            //Imprimir el resultado en consola mediante los ciclos for.
            Console.WriteLine("La matriz identidad es:");
            
            for (int ren = 0; ren < 3; ren++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Write(Math.Round(matriz[ren,col])+" ");
                }
                Console.WriteLine();
            }
            Console.Read();
	}
}