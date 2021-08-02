using System;
					
public class Program
{
	public static void Main()
	{
		//3x+y=1
		//7x+2y=4
		//Definir de cuanto se va a incrementar.
		double paso = 1;
			
			//Primer ciclo for para recorrer los valores de x
            for (double x = -100; x < 100; x = x + paso)
            {
                //segundo for para los valores de y.
				for (double y = -100; y < 100; y = y + paso)
                {
                    //Condición con la ecuación(es).
					if (1 == 3 * x + y & 4 == 7 * x + 2 * y)
                    {
                        Console.WriteLine("La solución es x=" + x + " y=" + y);
                        break;
                    }
                }
            }

            Console.ReadLine();
	}
}