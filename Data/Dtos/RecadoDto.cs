using Controle_Escolar.Data.Repository;

namespace Controle_Escolar.Data.Dtos
{
    [BsonCollection("Recado")]
    public class RecadoDto: Document
    {
        public string RecadoGeral { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
