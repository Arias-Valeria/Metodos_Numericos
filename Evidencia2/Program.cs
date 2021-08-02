using System;

namespace Evidencia2
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----------------------------------INCISO B. - NEWTON RAPSON.-----------------------------------
            double S, I, R, f1, f2, f3, epsilon = 0.001; //variables, funciones I margen de error en el sistema de ecuaciones.
            double[,] matriz1 = new double[3, 4]; //matriz jacobiana
            double pivote, factor; //variables del método de eliminación Gaussiana.
            //Valores arbitrarios de las variables, como no aparecen graficamente en Geogebra, se eligieron al azar.
            S = 12;
            I = 1;
            R = 3;
            double b = 0.74;
            double a = 0.24;
            //declarar las funciones con los valores establecidos previamente.
            f1 = S + I + R - 128;
            f2 = (b * I) - R;
            f3 = 128 - I -R - S;

            while (Math.Abs(f1) > epsilon | Math.Abs(f2) > epsilon | Math.Abs(f3) > epsilon)
            {
                //----se calculan las funciones ya que con cada ciclo cambian.
                f1 = S + I + R - 128;
                f2 = (b * I) - R;
                f3 = - S - I - R + 128;

                //Matriz de Jacobi con los valores derivados, la última columna es el resultado de las ecuaciones originales por -1;
                matriz1[0, 0] = 1;
                matriz1[0, 1] = 1;
                matriz1[0, 2] = 1;
                matriz1[0, 3] = -f1;
                matriz1[1, 0] = 0;
                matriz1[1, 1] = b;
                matriz1[1, 2] = -1;
                matriz1[1, 3] = -f2;
                matriz1[2, 0] = -1;
                matriz1[2, 1] = -1;
                matriz1[2, 2] = -1;
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
                // Se suma a las variables los nuevos valores obtenidos I se evaluan en la nueva matriz.
                S = S + matriz1[0, 3];
                I = I + matriz1[1, 3];
                R = R + matriz1[2, 3];
            }
            //Se Imprimen los resultados de la matriz
            Console.WriteLine(".---------------------INCISO B.--------------------- ");
            Console.WriteLine("Susceptibles " + S);
            Console.WriteLine("Infectados " + I);
            Console.WriteLine("Recuperados: " + R);
            Console.ReadLine();
        }
    }
}
