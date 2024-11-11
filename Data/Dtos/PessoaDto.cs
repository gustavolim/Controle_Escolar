using Controle_Escolar.Data.Context;
using Controle_Escolar.Data.Repository;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Controle_Escolar.Data.Dtos
{
    [BsonCollection("Pessoa")]
    public class PessoaDto : Document
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        [JsonIgnore]
        public string Senha { get; set; }
        public string Usuario { get; set; }
        public Perfil TipoPerfil { get; set; }

        public List<string> NumRaAluno { get; set; } = new List<string>();

    }

    [BsonCollection("Crianca")]
    public class CriancaDto : Document
    {
        public string Turma { get; set; }
        public string Nome { get; set; }
        public string NumRa { get; set; }
        public DateTime DtNascimento { get; set; }
    }

    public enum Perfil
    {
        Responsavel = 1,
        Monitoria = 2
    }

    public class PessoaRequest
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Usuario { get; set; }
        public Perfil TipoPerfil { get; set; }

        public List<string> NumRaAluno { get; set; } = new List<string>();

    }

}
