using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Collections
{
    public class Utils
    {
        public static IList<T> Shuffle<T>(IList<T> list)
        {
            Random lRandom = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = lRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }
}
