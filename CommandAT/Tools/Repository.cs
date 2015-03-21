using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CommandAT.Tools
{
    internal class Repository
    {
        public string Root
        {
            get { return root; }
            set { root = value; }
        }
        private string root = @"\";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string name = @"data";

        private Serializer serializer = new Serializer();

        public T Read<T>() where T : class
        {
            T output = default(T);

            using (var fs = File.Open(GetFullpathChecked(), FileMode.OpenOrCreate))
            {
                output = serializer.Deserialize<T>(fs);
            }

            return output;
        }

        public void Write<T>(T instance) where T : class
        {
            var fullpath = GetFullpathChecked();
            if (File.Exists(fullpath))
                File.Delete(fullpath);

            using (var fw = File.OpenWrite(fullpath))
            using (var ms = serializer.Serialize(instance))
            {
                const int bufferSize = 512;
                var bufferFile = new byte[bufferSize];
                var count = bufferSize;

                while (count > 0 && count == bufferSize)
                {
                    count = ms.Read(bufferFile, 0, bufferSize);
                    fw.Write(bufferFile, 0, count);
                }
            }
        }

        private string GetFullpathChecked()
        {
            var fullpath = GetFullpath();
            CheckDirectory(fullpath);
            return fullpath;
        }

        private void CheckDirectory(string fullpath)
        {
            var directory = Path.GetDirectoryName(fullpath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        private string GetFullpath()
        {
            return Path.Combine(Root, Path.ChangeExtension(Name, "xml"));
        }
    }
}
