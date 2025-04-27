using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    public static class Kolo
    {
        public static (double Pole, double Obwod) ObliczKolo(double promien)
        {
            if(promien <= 0)
            {
                throw new ArgumentException("Promień musi być dodatni");
            }
            double Pole = Math.PI * Math.Pow(promien, 2);
            double Obwod = 2 * Math.PI * promien;
            return (Pole, Obwod);
        }
    }
}
