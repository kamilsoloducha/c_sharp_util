using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Collections
{
    public static class NavigationExtension
    {

        public static T Previous<T>(this IList<T> list, T currentItem)
        {
            if (currentItem == null)
            {
                return default(T);
            }
            int currentIndex = list.IndexOf(currentItem);
            if (currentIndex <= 0)
            {
                return default(T);
            }
            return list[--currentIndex];
        }

        public static T Next<T>(this IList<T> list, T currentItem)
        {
            if (currentItem == null)
            {
                return default(T);
            }
            int currentIndex = list.IndexOf(currentItem);
            if (currentIndex < 0 || currentIndex >= list.Count - 1)
            {
                return default(T);
            }
            return list[++currentIndex];
        }
    }
}
