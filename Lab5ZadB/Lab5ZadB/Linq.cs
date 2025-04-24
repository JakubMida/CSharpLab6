using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5ZadB
{
    public static class Linq
    {
        public static (TKey min, TKey max) MinMax<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        where TKey : IComparable<TKey>
        {
            if (source == null || !source.Any())
                throw new InvalidOperationException("Kolekcja nie zawiera żadnych elementów.");

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
