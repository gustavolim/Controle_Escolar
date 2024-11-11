using Controle_Escolar.Data.Dtos;

namespace Controle_Escolar.Services
{
    public interface IPessoaService
    {
        //Task<List<PessoaDto>> GetPessoas();

        Task InsertPessoa(PessoaRequest pessoaDto, string senha);
        Task InsertAluno(CriancaDto criancaDto);
        Task UpdatePessoa(PessoaRequest pessoaDto, string? senha);
        Task UpdateAluno(CriancaDto criancaDto);
        Task<List<PessoaDto>> ListPessoas();
        Task<PessoaDto> Login(string usuario, string senha);
        Task<List<CriancaDto>> ListAluno();
        Task<CriancaDto> RetornaAlunoRa(string RA);
        Task<List<CriancaDto>> RetornaAlunoTurma(string turma);

    }
}
