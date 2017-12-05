using System.Collections.Generic;

namespace Util.Collections
{
    public static class CollectionExtensitons
    {

        public static void AddRange<T>(this ICollection<T> destination, IEnumerable<T> source)
        {
            if(source == null)
            {
                return;
            }
            foreach(T item in source)
            {
                destination.Add(item);
            }
        }

    }
}
