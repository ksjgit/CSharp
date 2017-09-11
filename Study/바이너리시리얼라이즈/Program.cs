using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace 바이너리시리얼라이즈
{
    [Serializable]
    public class SampleSerializableClass
    {
        public string Value { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SampleSerializableClass obj = new SampleSerializableClass();
            obj.Value = "Hello";
            IFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream("sample.bin", FileMode.Create))
            {
                formatter.Serialize(stream, obj);
            }
            using (Stream stream = new FileStream("sample.bin", FileMode.Open))
            {
                SampleSerializableClass read = (SampleSerializableClass)formatter.Deserialize(stream);
                Console.WriteLine(read.Value);

                Console.ReadLine();
            }
         }
    }
}
