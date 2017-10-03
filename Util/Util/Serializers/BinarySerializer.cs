using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Util.Serializers
{
    public class BinarySerializer<T> : ISerializer<T>
    {

        public BinarySerializerSettings Settings { get; set; }

        public bool Write(T obj)
        {
            using (Stream stream = File.Open(Settings.Path, Settings.Append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, obj);
            }
            return true;
        }

        public T Read()
        {
            if (!File.Exists(Settings.Path))
            {
                return default(T);
            }
            T obj;
            using (Stream stream = File.Open(Settings.Path, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                obj = (T)binaryFormatter.Deserialize(stream);
            }
            if (Settings.RemoveAfterRead)
            {
                File.Delete(Settings.Path);
            }
            return obj;
        }

    }
}
