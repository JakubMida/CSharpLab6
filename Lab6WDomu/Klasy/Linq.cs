using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    public static class Linq
    {
        public static (TKey min, TKey max) MinMax<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> selector)
            where TKey : IComparable<TKey>
        {
            if(source == null)
            {
                throw new ArgumentException("Kolekcja jest pusta");
            }
            using var enumerator = source.GetEnumerator();
            enumerator.MoveNext();

            TKey min = selector(enumerator.Current);
            TKey max = min;

            while (enumerator.MoveNext())
            {
                TKey value = selector(enumerator.Current);
                if (value.CompareTo(min) < 0) min = value;
                if (value.CompareTo(max) > 0) max = value;
            }

            return (min, max);
        }
    }
}
