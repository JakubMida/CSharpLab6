using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Lab6zadAWDomu
{
    static public class Funkcja
    {
        public static (double x, double y, double wartosc) ZnajdzMinimumFunkcji2D(
            double minX, double maxX, double minY, double maxY, long liczbaIteracji, 
            Func<double,double, double> funkcja)
        {
            Random rnd = new Random();
            double? najlepszyX = null;
            double? najlepszyY = null;
            double najlepszaWartosc = double.MaxValue;
            if(liczbaIteracji <= 0)
            {
                throw new ArgumentException("Liczba iteracji musi być > 0");
            }

            for (long i = 0; i < liczbaIteracji; i++)
            {
                double x = rnd.NextDouble() * (maxX - minX) + minX;
                double y = rnd.NextDouble() * (maxY - minY) + minY;
                double wartosc = funkcja(x, y);

                if(wartosc < najlepszaWartosc)
                {
                    najlepszyX = x;
                    najlepszyY = y;
                    najlepszaWartosc = wartosc;
                }
            }
            return ((double)najlepszyX, (double)najlepszyY, najlepszaWartosc);
        }
    }
}
