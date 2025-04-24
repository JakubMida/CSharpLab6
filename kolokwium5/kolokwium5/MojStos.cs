using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokwium5
{
    public class MojStos<T>
    {
        List<T> dane = new List<T>();

        public void DodajNaGore(T element)
        {
            dane.Add(element);
        }

        public T ZdejmijZGory()
        {
            if (dane.Count > 0)
            {
                int index = dane.Count - 1;
                var element = dane[index];
                dane.RemoveAt(index);
                return element;
            }
            else
            {
                throw new ArgumentException("Stos jest pusty");
            }

        }
    }
}
