using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Controle_Escolar.Data.Context
{
    public abstract class MongoEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonExtraElements]
        public IDictionary<string,object> ExtraData { get; set; }
    }
}
