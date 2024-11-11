using Controle_Escolar.Data.Dtos;
using Controle_Escolar.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Controle_Escolar.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IMongoRepository<PessoaDto> pessoaDao;
        private readonly IMongoRepository<CriancaDto> criancaDao;


        public PessoaService(IMongoRepository<PessoaDto> pessoaDao, IMongoRepository<CriancaDto> criancaDao)
        {
            this.pessoaDao = pessoaDao;
            this.criancaDao = criancaDao;
        }

        public async Task InsertPessoa(PessoaRequest pessoaDto, string senha)
        {
            PessoaDto pessoa;
            var pessoaRetorn = await pessoaDao.FindOneAsync(x => x.Cpf == pessoaDto.Cpf);
            if (pessoaRetorn == null)
            {
                pessoa = new();
                pessoa.Nome = pessoaDto.Nome ?? pessoa.Nome;
                pessoa.Cpf = pessoaDto.Cpf ?? pessoa.Cpf;
                pessoa.Usuario = pessoaDto.Usuario ?? pessoa.Usuario;
                pessoa.TipoPerfil = pessoaDto.TipoPerfil;

                // Se a senha for fornecida, atualize-a
                if (!string.IsNullOrEmpty(senha))
                {
                    pessoa.Senha = senha;
                }

                pessoa.NumRaAluno = pessoaDto.NumRaAluno
                    ?? pessoaDto.NumRaAluno;

                await pessoaDao.InsertOneAsync(pessoa);
            }
        }

        public async Task InsertAluno(CriancaDto criancaDto)
        {
            await criancaDao.InsertOneAsync(criancaDto);
        }

        public async Task<PessoaDto> Login(string usuario, string senha)
        {
            var login = await pessoaDao.FindOneAsync(x => x.Usuario == usuario && x.Senha == senha);

            if (login == null)
                return new PessoaDto();

            return login;
        }

        public async Task UpdatePessoa(PessoaRequest pessoaDto, string? senha)
        {

            var pessoa = await pessoaDao.FindOneAsync(x => x.Cpf == pessoaDto.Cpf);
            if (pessoa != null)
            {
                pessoa.Nome = pessoaDto.Nome ?? pessoa.Nome;
                pessoa.Cpf = pessoaDto.Cpf ?? pessoa.Cpf;
                pessoa.Usuario = pessoaDto.Usuario ?? pessoa.Usuario;
                pessoa.TipoPerfil = pessoaDto.TipoPerfil;

                // Se a senha for fornecida, atualize-a
                if (!string.IsNullOrEmpty(senha))
                {
                    pessoa.Senha = senha;
                }

                pessoa.NumRaAluno = pessoaDto.NumRaAluno
                    ?? pessoaDto.NumRaAluno;
            }
            await pessoaDao.ReplaceOneAsync(pessoa);
        }

        public async Task UpdateAluno(CriancaDto criancaDto)
        {
            var aluno = await criancaDao.FindOneAsync(x => x.NumRa == criancaDto.NumRa);
            if (aluno != null)
                await criancaDao.ReplaceOneAsync(aluno);
        }

        public async Task<List<PessoaDto>> ListPessoas()
        {
            return await pessoaDao.FindAllAsync();
        }

        public async Task<List<CriancaDto>> ListAluno()
        {
            return await criancaDao.FindAllAsync();
        }

        public async Task<CriancaDto> RetornaAlunoRa(string RA)
        {
            return await criancaDao.FindOneAsync(x => x.NumRa == RA);
        }

        public async Task<List<CriancaDto>> RetornaAlunoTurma(string turma)
        {
            return await criancaDao.FindAllAsync(x => x.Turma == turma);
        }
    }
}
