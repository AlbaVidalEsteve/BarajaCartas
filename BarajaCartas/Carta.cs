using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BarajaCartas.Carta;

namespace BarajaCartas
{
    public class Carta
    {
        public enum ePalo
        {
            Oros,
            Copas,
            Espadas,
            Bastos
        }
        public int Num { get; set; }
        public ePalo Palo { get;  set; }
        public Carta()
        {
        }
        public Carta(int num, ePalo palo) 
        { 
            this.Num = num;
            this.Palo = palo;
        }
        public override string ToString()
        {
            return $"{Num} de {Palo}";
        }
    }

    
    
    
    
}
