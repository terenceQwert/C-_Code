using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp1
{
    public interface IShallowCopy<T>
    {
        T ShallowCopy();
    }

    public interface IDeepCopy<T>
    {
        T DeepCopy();
    }

    public class ShallowClone : IShallowCopy<ShallowClone>
    {
        public int Dta = 1;
        public List<string> ListData = new List<string>();
        public object ObjData = new object();
        public ShallowClone ShallowCopy() => (ShallowClone)this.MemberwiseClone();
    }
    [Serializable]
    public class DeepClone : IDeepCopy<DeepClone>
    {
        public int Data = 1;
        public List<string> ListData = new List<string>();
        public object objData = new object();
        public DeepClone DeepCopy()
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            bf.Serialize(memStream, this);
            memStream.Flush();
            memStream.Position = 0;
            return (DeepClone)bf.Deserialize(memStream);
        }
    }

    public class MultiClone : IShallowCopy<MultiClone>, IDeepCopy<MultiClone>
    {
        public int Data = 1;
        public List<string> ListData = new List<string>();
        public object objData = new object();
        public MultiClone ShallowCopy() { return (MultiClone)this.MemberwiseClone(); }
        public MultiClone DeepCopy()
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            bf.Serialize(memStream, this);
            memStream.Flush();
            memStream.Position = 0;
            return (MultiClone)bf.Deserialize(memStream);
        }
    }
}
