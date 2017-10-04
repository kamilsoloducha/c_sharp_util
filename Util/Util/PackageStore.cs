using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class PackageStore
    {

        private static Dictionary<int, object> _storeDictionary = new Dictionary<int, object>();

        public static bool Put(int pKey, object pObject)
        {
            lock (_storeDictionary)
            {
                if (_storeDictionary.ContainsKey(pKey))
                    return false;
                _storeDictionary.Add(pKey, pObject);
            }
            return true;
        }

        public static object Get(int pKey)
        {
            object lResult;
            lock (_storeDictionary)
            {
                if (!_storeDictionary.ContainsKey(pKey))
                    return null;
                lResult = _storeDictionary[pKey];
                _storeDictionary.Remove(pKey);
            }
            return lResult;
        }

    }
}
