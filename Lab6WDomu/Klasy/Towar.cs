using System.Collections.Specialized;

namespace Klasy
{
    public enum KategoriaTowaru
    {
        Elektronika, Spożywcze, Odzież
    }
    public class Towar
    {
        public string Nazwa {  get; set; }
        public decimal Cena { get; set; }
        public int Ilość {  get; set; }
        public KategoriaTowaru Kategoria { get; set; }

        public override string ToString()
        {
            return $"{Nazwa}, cena: {Cena:f2}, ilość: {Ilość}, Kategoria: {Kategoria}";
        }
    
        public void Wyswietl(Action<string> wyswieltTekst)
        {
            string tekst = ToString();
            wyswieltTekst(tekst);
        }
    }
}
