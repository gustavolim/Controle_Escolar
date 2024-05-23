using Controle_Escolar.Data.Dtos;
using Controle_Escolar.Data.Repository;
using System;

namespace Controle_Escolar.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IMongoRepository<PessoaDto> pessoaDao;

        public PessoaService(IMongoRepository<PessoaDto> pessoaDao)
        {
            this.pessoaDao = pessoaDao;
        }

        public async Task InsertPessoa(PessoaDto pessoaDto)
        {
            await pessoaDao.InsertOneAsync(pessoaDto);
        }

        public async Task<PessoaDto> Login(string cpf, string senha)
        {
            var login = await pessoaDao.FindOneAsync(x => x.Cpf == cpf && x.Senha == senha);

            if (login == null)
                return new PessoaDto();

            return login;
        }
    }
}
