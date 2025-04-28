using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolosGrupaA
{
    public class Kula
    {
        public double Promien {  get; set; }
        public string Material { get; set; }

        private static Dictionary<string, double> Gestosci = new Dictionary<string, double>
        {
            {"stal", 7.85  },
            {"drewno", 1.2 }
        };

        public double Masa()
        {
            double objetosc = 4.0 / 3.0 * Math.PI * Math.Pow(Promien, 3);
            double gestosc = Gestosci[Material];
            return objetosc * gestosc;
        }

        public void ZmienPromien(Func<double, double> r)
        {
            Promien = r(Promien);
        }
    }
}
