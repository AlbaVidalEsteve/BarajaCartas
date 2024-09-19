using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BarajaCartas
{
    internal class Baraja
    {
        List<Carta> cartaList = new List<Carta>();

        public Baraja()
        {
            CrearBaraja();
        }
        public void CrearBaraja()
        {
            foreach (Carta.ePalo palo in Enum.GetValues(typeof(Carta.ePalo)))
            {
                for (int i = 1; i <= 12; i++)
                {
                    Carta carta = new Carta(i, palo);
                    cartaList.Add(carta);
                }
            }
        }
        public void MostrarBaraja()
        {
            foreach (Carta carta in cartaList)
            {
                Console.WriteLine(carta);
            }
        }
        public void RobarCarta()
        {
            if (cartaList.Count == 0)
            {
                Console.WriteLine("No quedan cartas");
                return;
            }

            Carta ultimaCarta = cartaList.Last();
            cartaList.RemoveAt(cartaList.Count - 1);
            Console.WriteLine($"Robaste la carta: {ultimaCarta}");
        }
        public void RobarCartaPosicion()
        {
            if (cartaList.Count == 0)
            {
                Console.WriteLine("No quedan cartas");
                return;
            }
            Console.WriteLine($"Escoge una posicion entre 0 y {cartaList.Count}");
            int posicion = Convert.ToInt32(Console.ReadLine());
            if(posicion < 0 || posicion > cartaList.Count)
            {
                Console.WriteLine("Esta posición no es correcta");
            }

            Carta cartaRobada = cartaList[posicion];
            cartaList.RemoveAt(posicion);
            Console.WriteLine($"Robaste la carta: {cartaRobada}");
        }
        public void Barajar()
        {
            Random rnd = new Random();
            cartaList = cartaList.OrderBy(c => rnd.Next()).ToList();
            Console.WriteLine("Baraja barajada.");
        }
        public void RepartirCartas(List<Jugador> jugadores, int cartasPorJugador)
        {
            if (cartaList.Count < jugadores.Count * cartasPorJugador)
            {
                Console.WriteLine("No hay suficientes cartas en la baraja para repartir.");
                return;
            }

            for (int i = 0; i < cartasPorJugador; i++)
            {
                foreach (var jugador in jugadores)
                {
                    if (cartaList.Count == 0)
                        return;

                    Carta cartaRepartida = cartaList.First();
                    jugador.RecibirCarta(cartaRepartida);
                    cartaList.RemoveAt(0);
                }
            }
            Console.WriteLine("Cartas repartidas.");
        }
        public int DeterminarNumCartas(int numJugadores)
        {
            int numCartas = cartaList.Count()/numJugadores;
            return numCartas;
        }
        //public void MostrarBaraja()
        //{
        //    Console.WriteLine($"Quedan {cartaList.Count} cartas en la baraja.");
        //}
    }
}
