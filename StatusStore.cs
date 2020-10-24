using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp1
{
    public class StatusStore
    {
        public static void SerializeToFile<T> (T obj, string dataFile)
        {
            using (FileStream fileStream = File.Create(dataFile))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fileStream, obj);
            }
        }
        public static T DeserializeFromFile<T> ( string dataFile)
        {
            T obj = default(T);
            using (FileStream fileStream = File.OpenRead(dataFile))
            {
                BinaryFormatter bf = new BinaryFormatter();
                obj = (T)bf.Deserialize(fileStream);
            }
            return obj;
        }
    }
}
