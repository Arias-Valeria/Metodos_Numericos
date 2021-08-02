using System;
					
public class Program
{
	public static void Main()
	{
			double pivote, factor; //variables a emplear.
            double[,] jacobiana = new double[20, 3]; //Matriz jacobiana para la multiplicación.
            double[,] matriz = new double[3, 4]; //Matriz normal para guardar el resultado.

            //Matriz con las temperaturas de cada mes.
            double[] voltaje = { -2.4684, 56.8038, 4.8393, 13.2878, -0.1931, -19.5771,
                                   55.4146, 74.4829, 62.0632, 37.3616, 14.1876,
                                   72.9088, 81.5205, 120.7811, 156.3607, 141.7361,
                                   110.898, 129.7614, 192.8516, 253.4778 };
            //Matriz del tiempo transcurrido (en meses)
			double[] tiempo = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,
                                  17, 18, 19, 20};

            //Rellenar la matriz jacobiana (Derivadas parciales de cada uno de los valores)
			for (int i = 0; i < 20; i = i + 1)
            {
                jacobiana[i, 0] = tiempo[i] * tiempo[i];
                jacobiana[i, 1] = Math.Sin(tiempo[i]);
                jacobiana[i, 2] = Math.Exp(tiempo[i] / 10);
            }

            //Multiplicación de matrices (Matriz jacobiana por la transpuesta)
            //------------------------------
            for (int i = 0; i < 3; i = i + 1)
                for (int j = 0; j < 3; j = j + 1)
                    for (int k = 0; k < 20; k = k + 1)
						// multiplica la matriz por la transpuesta.
                        matriz[i, j] = matriz[i, j] + jacobiana[k, i] * jacobiana[k, j];
   
            for (int i = 0; i < 3; i = i + 1)
                for (int j = 0; j < 1; j = j + 1)
                    for (int k = 0; k < 20; k = k + 1)
						//multiplica la transpuesta ´por todos los valores de y
                        matriz[i, 3] = matriz[i, 3] - voltaje[k] * jacobiana[k, i];
            //------------------------------

                //Eliminación Gaussiana
                //------------------------------
                for (int reng = 0; reng < 3; reng = reng + 1)
                {
                    pivote = matriz[reng, reng];
                    for (int colu = 0; colu < 4; colu = colu + 1)
                        matriz[reng, colu] = matriz[reng, colu] / pivote;
                    for (int reng_elimi = 0; reng_elimi < 3; reng_elimi = reng_elimi + 1)
                    if (reng_elimi != reng)
                    {
                        factor = matriz[reng_elimi, reng];
                        for (int colu_elimi = 0; colu_elimi < 4;
                            colu_elimi = colu_elimi + 1)
                            matriz[reng_elimi, colu_elimi] = matriz[reng_elimi,
                                colu_elimi] - factor * matriz[reng, colu_elimi];
                    }
                }
                //------------------------------

                //Imprime los valores de las variables
				 Console.WriteLine(matriz[0, 3] + " " + matriz[1, 3] + " " + matriz[2, 3]+ " ");

				 Console.ReadLine();

	}
}