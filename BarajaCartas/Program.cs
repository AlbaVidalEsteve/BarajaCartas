using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Crear dos clases en su archivo propio (carta y baraja):
atributos de la clase Carta:
- 	Número (type -> int)
- 	Palo (type -> enum)
atributos de la clase Baraja:
- 	Cartas -> tipo -> lista de cartas list <cartas> (lista de objetos)

la lista hay que crearla primero inicializarla en blanco en el constructor de Baraja

mtodos -> devuelven la carta robada (la carta robada desaparece de la baraja) -> hay que inicializar la baraja
 -	robar carta de arriba
-	barajar
- 	robar al azar
-	robar en posición n

//Clase jugego con la funcion iniciar juego que va al main.
      
*/

/*
 Método toString en todas las clases -> devuelve un string de todas las clases con detalles de cada clase.
No lo muestra solo lo devuelve.

 */

namespace BarajaCartas
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            EmpezarJuego();
            Console.ReadKey();

        }
        //funcion empezar juego
        static void EmpezarJuego()
        { 
            //Creamos baraja para el juego
            Baraja baraja = new Baraja();
            //baraja.MostrarBaraja();
            baraja.Barajar();
            //baraja.MostrarBaraja();

            //Creamos jugadores
            List<Jugador> jugadores = new List<Jugador>();
            Console.WriteLine("Número de jugadores:");
            int numJugadores = Convert.ToInt32(Console.ReadLine());
            //añadir que num de jugadores solo pueda ser entre 2 y 5
            for (int i = 1; i <= numJugadores; i++)
            {
                jugadores.Add(new Jugador($"Jugador {i}"));
            }                 
            MostrarJugadores();

            //Determinamos numero de cartas por jugador
            int numCartas = baraja.DeterminarNumCartas(jugadores.Count());

            baraja.RepartirCartas(jugadores, numCartas);

            //Mostramos las manos del jugador (Poner dentro de una función?)
            void MostrarManosActuales()
            {
                foreach (Jugador jugador in jugadores)
                {
                    jugador.MostrarMano();
                }
            }

            //Funcion ronda
        
            do
            {
                IniciarRonda();
                
            } while (jugadores.Count() > 1);
            //Determinar Ganador
            if (jugadores.Count == 1)
            {
                Console.WriteLine($"\nEl ganador del juego es {jugadores[0]}!");
                Console.ReadKey();
            }
            void IniciarRonda()
            {
                List<Carta> cartasMesa = new List<Carta>();
                Console.WriteLine("\n--- Todos los jugadores tiran una carta ---");
                Jugador ganador = null;
                Carta cartaGanadora = null;

                foreach (Jugador jugador in jugadores)
                {
                    Carta cartaTirada = jugador.TirarCarta();
                    cartasMesa.Add(cartaTirada);
                    if (cartaTirada != null)
                    {
                        if (cartaGanadora == null || cartaTirada.Num > cartaGanadora.Num)
                        {
                            cartaGanadora = cartaTirada;
                            ganador = jugador;
                        }else if(cartaTirada.Num == cartaGanadora.Num)
                        {
                           if((int)cartaTirada.Palo > (int)cartaGanadora.Palo)
                            {
                                cartaGanadora = cartaTirada;
                                ganador = jugador;
                                //CONTINUAR AQUI!!!!!
                            }
                        }
                    }
                    jugador.MostrarNumCartas();
                    jugador.Perder(jugadores);
                }
                
                Console.WriteLine($"El ganador de la ronda es:{ganador}");
                ganador.RecibirCarta( cartasMesa );
                
                ////foreach (Jugador jugador in jugadores)
                //{
                //    Baraja manoJugador = Mano.Count();
                //    if (manoGanadora != null)
                //    {
                //        if (manoGanadora == null || manoJugador > manoGanadora)
                //        {
                //            manoGanadora = ma;
                //            ganador = jugador;
                //        }
                //        else if (cartaTirada.Num == cartaGanadora.Num)
                //        {
                //            if ((int)cartaTirada.Palo > (int)cartaGanadora.Palo)
                //            {
                //                cartaGanadora = cartaTirada;
                //                ganador = jugador;
                //                //CONTINUAR AQUI!!!!!
                //            }
                //        }
                //    }

                //}
            }

            void MostrarJugadores()
            {
                foreach (Jugador jugador in jugadores)
                {
                    Console.WriteLine(jugador);
                }
            }

            

            //Función repartir Cartas de la baraja entre los jugadores
                //pregunta numero de jugadores
                // crea 2-5 juegadores
                // estan en una lista de jugadores?¿?¿

            // bucle que de turno a los jugadores y le pregunta la accion
            // switch case? de las acciones que puede hacer cada jugador

            //empate
                //si hay empate de numero dar orden de prioridad de palos (este)
                //si hay empate los que han empatado repiten ronda ellos tres

            //clase jugador
                //cada jugador tiene si baraja son iguales pero objetos diferentes
                // cada jugador tiene metodos:
                //  robarcartaultima
                //  robarcartaposicion
                //  barajar
                // tirar carta


            //Pascal
                //public int Numero{get;set;}
                //Enum.GetValues(typeof(ePalo)) -> explorar los valores de un Enum
                // no hacer for con los indices -> usando un foreach. (con una lista?)
        }
    }
}
