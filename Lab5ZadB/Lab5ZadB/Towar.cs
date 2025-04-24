using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5ZadB
{
    public enum KategoriaTowaru
    {
        Elektronika, Spożywcze, Chemia
    }
    public class Towar
    {
        public string Nazwa {  get; set; }
        public decimal Cena { get; set; }
        public int Ilosc {  get; set; }
        public KategoriaTowaru Kategoria { get; set; }

        public override string ToString()
        {
            return $"{Nazwa} | Cena: {Cena:f2} | Ilość: {Ilosc} | Kategoria: {Kategoria}";
        }
    }
}
