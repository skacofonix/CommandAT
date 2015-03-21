using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace CommandAT.Tools
{
    internal class Serializer
    {
        public Stream Serialize<T>(T instance) where T : class
        {
            var serializer = CreateSerializer<T>();

            var outputStream = new MemoryStream();
            serializer.Serialize(outputStream, instance);
            outputStream.Position = 0;

            return outputStream;
        }

        public T Deserialize<T>(Stream inputStream) where T : class
        {
            if (inputStream == null)
                throw new ArgumentNullException("inputStream");

            T output = default(T);

            inputStream.Position = 0;

            var deserializer = CreateSerializer<T>();
            using (var sr = new StreamReader(inputStream))
            {
                try
                {
                    output = deserializer.Deserialize(sr) as T;
                }
                catch
                {
                    output = default(T);
                }
            }

            return output;
        }

        private XmlSerializer CreateSerializer<T>()
        {
            var serializer = new XmlSerializer(typeof(T));
            serializer.UnknownAttribute += (s, e) => Log("UnknownAttribute");
            serializer.UnknownElement += (s, e) => Log("UnknownElement");
            serializer.UnknownNode += (s, e) => Log("UnknownNode");
            serializer.UnreferencedObject += (s, e) => Log("UnreferencedObject");
            return serializer;
        }

        private void Log(string message)
        {
            Trace.WriteLine(message, this.GetType().ToString());
        }
    }
}
