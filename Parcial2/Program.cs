using System;

namespace Parcial2
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----------------------------------BUSQUEDA EXHAUSTIVA - INCISO A.-----------------------------------
            for (int i = -1000; i < 1000; i++)
            {
                int ec = (i/2) + i + 2*i;
                if (56 == ec)
                {
                    Console.WriteLine(".---------------------INCISO A.--------------------- ");
                    Console.WriteLine("Peces en la pecera pequeña: " + (i/2));
                    Console.WriteLine("Peces en la pecera mediana: " + i);
                    Console.WriteLine("Peces en la pecera grande: "+ (i*2));
                    Console.WriteLine(" ");
                    break;
                }
            }

            //-----------------------------------INCISO B. - NEWTON RAPSON.-----------------------------------
            double x, y, z, f1, f2, f3, epsilon = 0.001; //variables, funciones y margen de error en el sistema de ecuaciones.
            double[,] matriz1 = new double[3, 4]; //matriz jacobiana
            double pivote, factor; //variables del método de eliminación Gaussiana.
            //Valores arbitrarios de las variables, como no aparecen graficamente en Geogebra, se eligieron al azar.
            x = 3;
            y = 5;
            z = 7;
            //declarar las funciones con los valores establecidos previamente.
            f1 = -(2*x) + y + z;
            f2 = y-(2*z);
            f3 = x + y + z - 1;

            while (Math.Abs(f1) > epsilon | Math.Abs(f2) > epsilon | Math.Abs(f3) > epsilon)
            {
                //----se calculan las funciones ya que con cada ciclo cambian.
                f1 = -(2 * x) + y + z;
                f2 = y - (2 * z);
                f3 = x + y + z - 1;

                //Matriz de Jacobi con los valores derivados, la última columna es el resultado de las ecuaciones originales por -1;
                matriz1[0, 0] = -2;
                matriz1[0, 1] = 1;
                matriz1[0, 2] = 1;
                matriz1[0, 3] = -f1;
                matriz1[1, 0] = 0;
                matriz1[1, 1] = 1;
                matriz1[1, 2] = -2;
                matriz1[1, 3] = -f2;
                matriz1[2, 0] = 1;
                matriz1[2, 1] = 1;
                matriz1[2, 2] = 1;
                matriz1[2, 3] = -f3;

                //Inicio la eliminación Gaussiana
                for (int reng = 0; reng < 3; reng++)
                {
                    pivote = matriz1[reng, reng];
                    for (int colu = 0; colu < 4; colu++)
                    {
                        matriz1[reng, colu] = matriz1[reng, colu] / pivote;
                    }

                    for (int reng_elimi = 0; reng_elimi < 3; reng_elimi++)
                    {
                        if (reng_elimi != reng)
                        {
                            factor = matriz1[reng_elimi, reng];
                            for (int colu_elimi = 0; colu_elimi < 4; colu_elimi = colu_elimi + 1)
                            {
                                matriz1[reng_elimi, colu_elimi] = matriz1[reng_elimi, colu_elimi]
                                                                 - factor * matriz1[reng, colu_elimi];
                            }
                        }
                    }
                }

                //Termina la eliminación Gaussiana
                // Se suma a las variables los nuevos valores obtenidos y se evaluan en la nueva matriz.
                x = x + matriz1[0, 3];
                y = y + matriz1[1, 3];
                z = z + matriz1[2, 3];
            }
            //Se Imprimen los resultados de la matriz
            Console.WriteLine(".---------------------INCISO B.--------------------- ");
            Console.WriteLine("La porción de Luis: " + x);
            Console.WriteLine("La porción de Pedro: " + y);
            Console.WriteLine("La porción de Ernesto:" + z);



            //-----------------------------------INCISO C - GAUSS-JORDAN-----------------------------------
            //Definimos la matriz de los coeficientes.
            double[,] matriz = { { 1, -1, -21 },
                                 { 1, 1, 47 }};
            //Proceso de Gauss.
            for (int ren = 0; ren < 2; ren++)
            {
                pivote = matriz[ren, ren];

                for (int col = 0; col < 3; col++)
                {
                    //Se divide el renglon entre el pivote
                    matriz[ren, col] = matriz[ren, col] / pivote;
                }
                //Se eliminan los valores que están en la misma columna que el pivote y se selecciona el renglón.
                for (int reng_elimi = 0; reng_elimi < 2; reng_elimi++)
                {
                    if (reng_elimi != ren)
                    {
                        //Se selecciona el factor que multplicará al renglón principal, después se elimina.
                        factor = matriz[reng_elimi, ren];

                        //Se resta todo el renglón principal menos el renglón a eliminar
                        for (int colu_elimi = 0; colu_elimi < 3; colu_elimi++)
                        {
                            matriz[reng_elimi, colu_elimi]
                                = matriz[reng_elimi, colu_elimi] - factor
                                * matriz[ren, colu_elimi];
                        }
                    }
                }
            }
            //Imprimir variables.
            Console.WriteLine(" ");
            Console.WriteLine(".---------------------INCISO C.--------------------- ");
            Console.WriteLine("La edad de Juan es: " + matriz[0,2]);
            Console.WriteLine("La edad de Andrés es: " + matriz[1, 2]);

            //-----------------------------------INCISO D. GAUSS-JORDAN-----------------------------------
            double[,] matriz3 = { { 1, 1, 12 },
                                 { 0.5, -2, 0 }};
            double pivote3, factor3;
            //Proceso de Gauss.
            for (int ren = 0; ren < 2; ren++)
            {
                pivote3 = matriz3[ren, ren];

                for (int col = 0; col < 3; col++)
                {
                    //Se divide el renglon entre el pivote
                    matriz3[ren, col] = matriz3[ren, col] / pivote3;
                }
                //Se eliminan los valores que están en la misma columna que el pivote y se selecciona el renglón.
                for (int reng_elimi = 0; reng_elimi < 2; reng_elimi++)
                {
                    if (reng_elimi != ren)
                    {
                        //Se selecciona el factor que multplicará al renglón principal, después se elimina.
                        factor3 = matriz3[reng_elimi, ren];

                        //Se resta todo el renglón principal menos el renglón a eliminar
                        for (int colu_elimi = 0; colu_elimi < 3; colu_elimi++)
                        {
                            matriz3[reng_elimi, colu_elimi]
                                = matriz3[reng_elimi, colu_elimi] - factor3
                                * matriz3[ren, colu_elimi];
                        }
                    }
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine(".---------------------INCISO D.--------------------- ");
            Console.WriteLine("El primer número es: " + matriz3[0, 2]);
            Console.WriteLine("El segundo número es: " + matriz3[1, 2]);

            Console.ReadLine();

        }
    }
}
