
using Controle_Escolar.Data.Dtos;
using MongoDB.Driver;

namespace Controle_Escolar.Data.Context
{
    public class PessoaDbContext : MongoDbContext, IPessoaDbContext
    {
        private const string PESSOA_CONTEXT = "Pessoas";

        public PessoaDbContext(string connectString) : base(connectString)
        {
        }

        public IMongoCollection<PessoaDto> Pessas => base._database.GetCollection<PessoaDto>(PESSOA_CONTEXT);
    }
}
