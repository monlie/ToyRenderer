using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CSRenderer {
    class Tools {
        public static void ObjectToFile<T>(T t, string path) {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate)) {
                formatter.Serialize(stream, t);
                stream.Flush();
            }
        }

        public static T FileToObject<T>(string path) where T : class {
            using (FileStream stream = new FileStream(path, FileMode.Open)) {
                BinaryFormatter formatter = new BinaryFormatter();
                T result = formatter.Deserialize(stream) as T;
                return result;
            }
        }
    }
}
