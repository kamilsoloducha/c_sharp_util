using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Util.Serializers
{
    public class XmlSerializer<T> : ISerializer<T> where T : new()
    {

        public string Path { get; set; }

        public T Read()
        {
            XmlTextReader lXmlReader = null;
            StringReader lStringReader = null;
            if (!File.Exists(Path))
                return default(T);
            string lFileContent = null;
            using (StreamReader lReader = new StreamReader(Path))
            {
                lFileContent = lReader.ReadToEnd();

                lStringReader = new StringReader(lFileContent);
                XmlSerializer lXmlSerializer = new XmlSerializer(typeof(T));
                lXmlReader = new XmlTextReader(lStringReader);
                return (T)lXmlSerializer.Deserialize(lXmlReader);
            }
        }

        public bool Write(T obj)
        {
            XmlSerializer lXmlSerializer = new XmlSerializer(obj.GetType());
            StringWriter lWriter = new StringWriter();
            lXmlSerializer.Serialize(lWriter, obj);
            using (StreamWriter lStreamWriter = new StreamWriter(Path))
            {
                lStreamWriter.Write(lWriter.ToString());
            }
            return true;
        }
    }
}
