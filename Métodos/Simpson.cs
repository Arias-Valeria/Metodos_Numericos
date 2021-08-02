using System;
					
public class Program
{
	public static void Main()
	{
		//Declaración de variables.
            double incremento, altura1, altura2, altura3, total_alturas, x;
            double partes = 10000, area = 0, lim_sup, lim_inf;

            //El usuario ingresa los límites sup e inf
            Console.WriteLine("Ingrese el valor del límite inferior: ");
            lim_inf = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el valor del límite superior: ");
            lim_sup = int.Parse(Console.ReadLine());

            //calculamos el incremento (Delta x)
            incremento = (lim_sup - lim_inf) / partes;
            //Iniciamos x con el valor del límite inferior (es el punto de partida)
            x = lim_inf;

            //El bucle para realizar los cálculos de las alturas y el área.
            while (x < lim_sup)
            {
                //Calculamos la primera altura
                altura1 = Math.Exp(x * x);
                //Ahora la segunda altura
                x = x + incremento / 2;
                altura2 = Math.Exp(x * x);
                //Por último, la tercera altura.
                x = x + incremento / 2;
                altura3 = Math.Exp(x * x);
                //Calculamos las alturas totales mediante la fórmula de simpson.
                total_alturas = ((altura1 +  4 * altura2 + altura3) / 6) * incremento;
                //se calcula el área.
                area = area + total_alturas;
            }

            //imprimir los resultados.
            Console.WriteLine("La integración (Area) aproximada es: " + area);
            Console.ReadLine();
	}
}