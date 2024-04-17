using Controle_Escolar.Dao;
using Controle_Escolar.Data.Dtos;

namespace Controle_Escolar.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaDao pessoaDao;

        public PessoaService(IPessoaDao pessoaDao)
        {
            this.pessoaDao = pessoaDao;
        }

        public async Task<List<PessoaDto>> GetPessoas()
        {
            var teste = await pessoaDao.GetT(x => x.Nome);
            return await pessoaDao.GetT(x=> x);
        }
    }
}
