using Controle_Escolar.Data.Dtos;

namespace Controle_Escolar.Services
{
    public interface IPessoaService
    {
        //Task<List<PessoaDto>> GetPessoas();

        Task InsertPessoa(PessoaDto pessoaDto);
        Task<PessoaDto> Login(string cpf, string senha);
    }
}
