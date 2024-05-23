using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Controle_Escolar.Data.Repository
{

    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}
