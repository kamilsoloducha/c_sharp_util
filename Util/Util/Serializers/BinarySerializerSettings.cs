using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Serializers
{
    public class BinarySerializerSettings
    {

        public string Path { get; set; }
        public bool Append { get; set; }
        public bool RemoveAfterRead { get; set; }

    }
}
