using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JuegoDeLaVida
{
    class Program
    {
        static void Main(string[] args)
        {
            int largo, ancho, turnos, porcentaje;
            Console.Write("Largo: ");
            largo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ancho: ");
            ancho = Convert.ToInt32(Console.ReadLine());
            Console.Write("Turnos: ");
            turnos = Convert.ToInt32(Console.ReadLine());
            Console.Write("Porcentaje de celulas: ");
            porcentaje = Convert.ToInt32(Console.ReadLine());
            int[,] tablero = new int[largo,ancho];
            int[,] tablero_aux = new int[largo, ancho];
      
            int x, y;
            Random rand = new Random();
            
            int celulas = (int)((largo*porcentaje/100)*(ancho*porcentaje/100));
            int i = 0;
            while (i < celulas)
            {
                x = rand.Next(1, largo);
                y = rand.Next(1, ancho);
                if (tablero[x, y] == 0)
                {
                    tablero[x, y] = 1;
                    i++;
                }
            }

            for (int a = 0; a < turnos; a++)
            {
                Mostrar(tablero, largo, ancho);
                tablero = Comprobar(tablero, largo, ancho);
                System.Threading.Thread.Sleep(50);
            }
            Console.ReadKey();
        }
        static void Mostrar(int[,] tablero, int largo, int ancho)
        {
            Console.Clear();
            for(int i = 0; i < largo; i++)
            {
                for(int j = 0; j < ancho; j++)
                {
                    if (tablero[i, j] == 0)
                        Console.Write(" ");
                    else
                        Console.Write("■");
                }
                Console.Write('\n');
            }
        }
        static int[,] Comprobar(int[,] tablero, int largo, int ancho)
        {
            for (int i = 0; i < largo; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    int celulas = 0;
                    if (i == 0 && j == 0)
                        celulas = tablero[i, j + 1] + tablero[i + 1, j] + tablero[i + 1, j + 1];
                    else if (i == 0 && j > 0 && (j < (ancho - 1)))
                        celulas = tablero[i, j - 1] + tablero[i, j + 1] + tablero[i + 1, j - 1] + tablero[i + 1, j] + tablero[i + 1, j + 1];
                    else if (i > 0 && j == 0 && (i < (largo - 1)))
                        celulas = tablero[i - 1, j] + tablero[i - 1, j + 1] + tablero[i, j + 1] + tablero[i + 1, j] + tablero[i + 1, j + 1];
                    else if (i > 0 && j > 0)
                    { 
                        if ((i + 1) < largo && (j + 1) < ancho)
                            celulas = tablero[i - 1, j - 1] + tablero[i - 1, j] + tablero[i - 1, j + 1] + tablero[i, j - 1] + tablero[i, j + 1] + tablero[i + 1, j - 1] + tablero[i + 1, j] + tablero[i + 1, j + 1];
                        else if ((i + 1) < largo && (j + 1) > ancho)
                            celulas = tablero[i - 1, j - 1] + tablero[i - 1, j] + tablero[i, j - 1] + tablero[i + 1, j - 1] + tablero[i + 1, j];
                        else if ((i + 1) > largo && (j + 1) < ancho)
                            celulas = tablero[i - 1, j - 1] + tablero[i - 1, j] + tablero[i - 1, j + 1] + tablero[i, j - 1] + tablero[i, j + 1];
                        else
                            celulas = tablero[i - 1, j - 1] + tablero[i - 1, j] + tablero[i, j - 1];
                    }
                    
                    if (celulas < 2)
                    {
                        tablero[i, j] = 0;
                    }
                    else if(celulas > 3)
                    {
                        tablero[i, j] = 0;
                    }
                    else if(celulas ==3)
                    {
                        tablero[i, j] = 1;
                    } 
                }
            }
            return tablero;
        }
    }
}
