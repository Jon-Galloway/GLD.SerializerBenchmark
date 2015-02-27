using System;
using System.Collections.Generic;

namespace GLD.SerializerBenchmark
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Input:
            // SerializerName[Json.NET, Bond...] / Format[JSON, XML, Binary, Specific...] / 
            // Data [int, string, class...] / TestRepetitions
            // Output: Average time per serialization + deserialization

            var repetitions = 300;
            Console.WriteLine("Repetitions: " + repetitions);
            var serializers = new Dictionary<string, ISerDeser>
            {
                {"AvroSerializer", new AvroSerializer(typeof(Person))},
                {"BinarySerializer",new BinarySerializer()},
                //{"BondSerializer", new BondSerializer(typeof(Person))}, // TODO: It does not debugged yet. 
                {"DataContractSerializerSerializer", new DataContractSerializerSerializer(typeof(Person))},  
                {"JilSerializer", new JilSerializer()},  // TODO: DateTime format?
                {"JsonFxSerializer", new JsonFxSerializer()},  // TODO: DateTime format?
                {"JsonNetSerializer",new JsonNetSerializer()},
                {"BsonDocumentSerializer",new BsonDocumentSerializer()},
                {"JsonNetStreamSerializer",new JsonNetStreamSerializer()},
                {"MsgPackSerializer", new MsgPackSerializer()},  // TODO: DateTime format?
                {"NetserializerSerializer", new NetSerializerSerializer(typeof(Person))},  
                {"ProtoBufSerializer", new ProtoBufSerializer()},
                {"ServiceStackJsonSerializer", new ServiceStackJsonSerializer()},  // TODO: DateTime format?
                {"ServiceStackTypeSerializer", new ServiceStackTypeSerializer()},  // TODO: DateTime format?
                {"XmlSerializer",new XmlSerializer(typeof (Person))},
           };

            Tester.Tests(repetitions, serializers);
            Console.ReadKey();
        }
    }
}