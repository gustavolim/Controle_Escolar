using Controle_Escolar.Data.Dtos;
using MongoDB.Driver;

namespace Controle_Escolar.Data.Context
{
    public interface IPessoaDbContext
    {
        IMongoCollection<PessoaDto> Pessas { get; }
    }
}
