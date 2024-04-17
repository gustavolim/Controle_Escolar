using Controle_Escolar.Data.Context;

namespace Controle_Escolar.Data.Dtos
{
    public class PessoaDto : MongoEntity
    {
        public string Nome { get; set; }
    }
}
