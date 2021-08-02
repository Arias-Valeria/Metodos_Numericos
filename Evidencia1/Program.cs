using System;
//Librerías usadas para mayor comodidad y eficiencia.
using System.Collections.Generic;
using System.Linq;

namespace Evidencia1
{
    class Program
    {
        static void Main(string[] args)
        {
            //declaración de funciones.
            static bool esPrimo(int numero)  //Función para saber sí un número es primo.
            {
                int contador = 0;
                for (int i = 1; i < (numero+1); i++) //para recorrer los números.
                {
                    if(numero % i == 0) //Para saber sí el número es divisible entre sí mismo y 1
                    {
                        contador++; //contador del número de divisores
                    }
                }
                if (contador > 2)//evaluar el contador.
                {
                    return false; //Si tiene más de 2 divisores, no es primo.
                }
                return true; //sí solo tiene 2 divisores, es primo.
            }
            
            static bool esPar(int numero) //Saber sí un número es par.
            {
                if(numero % 2 == 0)
                {
                    return true;
                }
                return false;
            }


            //Declaración de variables.
            int valores;
            int dato;
            int max = 16;
            int r;
            int inicio = 200;
            int final = 600;
            List<int> primos = new List<int>(); //trabajamos con list ya que es más cómodo y eficiente.
            int prim1;
            int prim2;
            int pasos = 0;

            //.*********************************INGRESO DE LOS DATOS.*********************************
            do
            {
                Console.WriteLine("Bienvenido, ¿cuántos números desea evaluar?");
                valores = int.Parse(Console.ReadLine());
                if (valores > 16)//Evalúa sí el valor ingresa está dentro de los límites estipulados.
                {
                    Console.WriteLine("\nLo sentimos, la cantidad a evaluar supera el límite de " + max + " espacios.\n");
                    r = 0;
                }
                else { r = 1;}
            } while (r !=1); //do-while para seguir pidiendo el dato en caso de ser necesario.

            //Crear el arreglo de los números después de haber validado el límite de elementos.
            int[] numeros = new int[valores];

            //.*********************************RELLENAR EL ARREGLO.*********************************
            for (int i = 0; i < valores; i++)
            {
                int s = 0;
                do
                {
                    Console.WriteLine("\nIngrese el valor " + (i + 1) + "(debe ser un número par y estar entre 200 y 600):");
                    dato = int.Parse(Console.ReadLine());
                    if (dato >= 200 && dato <=600 && esPar(dato))//evalúa si el dato se encuentra dentro de los parámetros.
                    {
                        numeros.SetValue(dato, i); //al cumplir la condición, se añade al arreglo.
                        s = 1;
                    }
                    else
                    {
                        Console.WriteLine("\nLo sentimos, el número no se encuentra dentro de los parámetros.");
                    }
                } while (s !=1);//Cuando la condición ha dejado de cumplirse, se termina este ciclo do-while para comenzar el siguiente.
            }

            //*********************************CALCULAR NUMEROS PRIMOS*********************************
            do
            {
                if (esPrimo(inicio) == true)//sí es Primo, agrega el valor a la lista.
                {
                    primos.Add(inicio);
                }
                inicio++; //de lo contrario, solo aumenta.
            } while (inicio < final);

            //*********************************SE EJECUTA LA CONJETURA*********************************
            foreach (var item in numeros)   //Este forEach recorre los valores del arreglo "números"
            {
                for (int i = 0; i < primos.Count; i++)//este for recorre los valores de la lista "primos"
                {
                    prim1 = primos.ElementAt(i); //inicializamos el primer valor primo.
                    prim2 = (item - prim1); //realizamos esta operación para tratar de encontrar el segundo primo.
                    
                    if (esPrimo(prim2) && prim2 >0 && prim2 !=1)//Sí el valor calculado de "prim2" es primo, mayor a 0 y diferente de 1, se imprime junto con prim1.
                    {
                        
                        Console.WriteLine(item + " = " + prim1 + " + " + prim2);
                        
                    }
                    pasos++;
                }
                Console.WriteLine("Pasos totales: " + pasos);
                Console.WriteLine("--------------------------------------------------------------------");
            }
            Console.ReadLine();
        }
    }
}
