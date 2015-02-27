using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace GLD.SerializerBenchmark
{
    internal class BsonDocumentSerializer : ISerDeser
    {
        public string Serialize<T>(object person)
        {
            return person.ToJson();
        }

        public T Deserialize<T>(string serialized)
        {
            return BsonSerializer.Deserialize<T>(serialized);
        }
    }
}