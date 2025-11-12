using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videojuego
{
    class Program
    {
        //Creamos un arreglo bidimensional para el tablero del juego
        static int[,] tablero = new int[3, 3];
        //Creamos un arreglo para los simbolos del tablero(J1 y J2)
        static char[] simbolo = { ' ', 'O', 'X' };

        static void Main(string[] args)
        {
            bool terminado = false;

            DibujarTablero();
            Console.WriteLine("Jugador 1 = O\nJugador 2 = X");

            do
            {
                //Turno de J1
                PreguntarPosicion(1); 
                //El J1 elige casilla
                DibujarTablero();
                //Se comprueba que J1 alla ganado
                terminado = ComprobarGanador();
                if(terminado == true)
                {
                    Console.WriteLine("¡El jugador 1 ha ganado!");
                    break;

                }
                else//Se comprueba si hay empate
                {
                    terminado = ComprobarEmpate();
                    if (terminado == true)
                    {
                        Console.WriteLine("¡ESTO ES UN EMPATE!");
                        break;
                    }
                    else //Turno del J2
                    {
                        PreguntarPosicion(2);
                        //Dibujar la casilla del J2
                        DibujarTablero();
                        //Se comprueba que el J2 alla ganado
                        terminado = ComprobarGanador();

                        if (terminado == true)
                        {
                            Console.WriteLine("¡El jugador 2 ha ganado!");
                            break;
                        }
                    }

                }


            } while (terminado == false); //El juego va a terminar cuando la variable sea true


        }

        static void DibujarTablero()
        {
            int fila = 0;
            int columna = 0;

            Console.WriteLine(); 
            Console.WriteLine("-------------"); //Dibujar la primera linea vertical
            for(fila = 0; fila < 3; fila++)
            {
                Console.Write("|"); //Dibuja la segunda linea horizontal
                for(columna=0; columna < 3; columna++)
                {
                    Console.Write(" {0} |", simbolo[tablero[fila, columna]]);
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }

        }

        static void PreguntarPosicion(int jugador)
        {
            int fila, columna;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Turno del jugador: {0}",jugador);
                do
                {
                    Console.Write("Selecciona la fila (1 a 3): ");
                    fila = Convert.ToInt32(Console.ReadLine());

                } while ((fila < 1) || (fila >3));

                do
                {
                    Console.Write("Selecciona la columna (1 a 3): ");
                    columna = Convert.ToInt32(Console.ReadLine());

                } while ((columna < 1) || (columna > 3));

               if(tablero[fila-1, columna-1] != 0)
                {
                    Console.WriteLine("Espacio ocupado");
                }

            } while (tablero[fila - 1, columna - 1] != 0);

           

            tablero[fila - 1, columna - 1] = jugador;

        }

        static bool ComprobarGanador()
        {
            bool ticTacToe = false;

            // Revisar filas
            for (int fila = 0; fila < 3; fila++)
            {
                if ((tablero[fila, 0] == tablero[fila, 1]) && (tablero[fila, 0] == tablero[fila, 2]) && (tablero[fila, 0] != 0))
                {
                    ticTacToe = true;
                }
            }

            // Revisar columnas
            for (int columna = 0; columna < 3; columna++)
            {
                if ((tablero[0, columna] == tablero[1, columna]) && (tablero[0, columna] == tablero[2, columna]) && (tablero[0, columna] != 0))
                {
                    ticTacToe = true;
                }
            }

            // Revisar diagonales
            if ((tablero[0, 0] == tablero[1, 1]) && (tablero[0, 0] == tablero[2, 2]) && (tablero[0, 0] != 0))
            {
                ticTacToe = true;
            }

            if ((tablero[0, 2] == tablero[1, 1]) && (tablero[0, 2] == tablero[2, 0]) && (tablero[0, 2] != 0))
            {
                ticTacToe = true;
            }

            return ticTacToe;
        }

        static bool ComprobarEmpate()
        {
            bool hayEspacio = false;
            int fila = 0;
            int columna = 0;

            for(fila = 0; fila < 3; fila++)
            {
                for(columna = 0; columna < 3; columna++)
                {
                    if(tablero[fila,columna] == 0) 
                    {
                        hayEspacio = true;
                    }
                }
            }

            return !hayEspacio; 
        }

    }
}
