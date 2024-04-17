using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Controle_Escolar.Data.Context
{
    public abstract class MongoDbContext
    {
        protected readonly IMongoDatabase _database;

        static MongoDbContext()
        {
            BsonSerializer.RegisterSerializer(typeof(decimal), new DecimalSerializer(BsonType.Double));
            BsonSerializer.RegisterSerializer(typeof(decimal?), new NullableSerializer<decimal>(new DecimalSerializer(BsonType.Double)));
        }

        protected MongoDbContext(string connectString)
        {
            MongoClient mongoClient = new MongoClient(connectString);

            if (mongoClient != null)
            {
                string text = connectString.Split(new char[1] { '/' }).Last();
                int num = text.IndexOf('?');
                _database = mongoClient.GetDatabase(text.Substring(0, (num > 0) ? num : text.Length));
            }
            else
            {
                Console.WriteLine("client null conectionString: " +  connectString);
            }
        }
    }
}
