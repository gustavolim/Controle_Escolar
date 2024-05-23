using Controle_Escolar.Data.Context;
using Controle_Escolar.Data.Repository;

namespace Controle_Escolar.Data.Dtos
{
    [BsonCollection("Pessoa")]
    public class PessoaDto: Document
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public Perfil TipoPerfil { get; set; }

        public List<Crianca> Criancas { get; set; } = new List<Crianca>();

    }

    [BsonCollection("Crianca")]
    public class Crianca: Document
    {
        public string Turma { get; set; }
        public string Nome { get; set; }
        public string Num_Ra { get; set; }
        public DateTime Dt_Nascimento { get; set; }
    }

    public enum Perfil
    {
        Responsavel = 1,
        Monitoria = 2
    }
}
