using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BarajaCartas.Carta;

namespace BarajaCartas
{
    public class Jugador
    {
        string id;
        public List<Carta> Mano { get; private set; }

        public Jugador(string id)
        {
            this.id = id;
            Mano = new List<Carta>();
        }

        public void RecibirCarta(Carta carta)
        {
            Mano.Add(carta);
        }

        public void MostrarMano()
        {
            Console.WriteLine($"{id} tiene las siguientes cartas:");
            foreach (var carta in Mano)
            {
                Console.WriteLine(carta);
            }
        }
        public void MostrarNumCartas()
        {
            int numCartasMano = Mano.Count;
            Console.WriteLine($"El jugador {id} tiene {numCartasMano}");   
        }
        public Carta TirarCarta()
        {
            if (Mano.Count == 0)
            {
                Console.WriteLine($"El {id} no tiene cartas para sacar.");
                return null;
            }
            Carta cartaTirada = Mano[0];
            Mano.Remove(cartaTirada);
            Console.WriteLine($"El {id} sacó la carta: {cartaTirada}");
            return cartaTirada;
        }
        public void RecibirCarta(List<Carta> cartasGanadas)
        {
            Mano.AddRange(cartasGanadas);
        }
        public void Perder(List<Jugador> jugadores)
        {
            if (Mano.Count == 0) {
                Console.WriteLine($"El {id} se ha quedado sin cartas");
            jugadores.Remove(this);
            }
        }
        public override string ToString()
        {
            return id;
        }
    }
}
