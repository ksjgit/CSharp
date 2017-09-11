using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace 바이너리시리얼라이즈2_json
{
    [DataContract]
    public class SampleSerializableClass
    {
        [DataMember()]
        public string Value { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SampleSerializableClass obj = new SampleSerializableClass();
            obj.Value = "Hello";
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(SampleSerializableClass));

            using (Stream stream = new FileStream("sample.json", FileMode.Create))
            {
                serializer.WriteObject(stream, obj);
            }
            using (Stream stream = new FileStream("sample.json", FileMode.Open))
            {
                SampleSerializableClass read = (SampleSerializableClass)serializer.ReadObject(stream);
                Console.WriteLine(read.Value);

                Console.ReadLine();
            }
        }
    }
}
