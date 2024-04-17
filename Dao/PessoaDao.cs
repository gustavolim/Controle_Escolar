using Controle_Escolar.Data.Context;
using Controle_Escolar.Data.Dtos;
using LinqToDB;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Controle_Escolar.Dao
{
    public class PessoaDao : IPessoaDao
    {
        private readonly IPessoaDbContext _context;

        public PessoaDao(IPessoaDbContext context)
        {
            _context = context;
        }
        public async Task<List<T?>> GetT<T>(Expression<Func<PessoaDto, T>> expression)
        {
            await CreateAsync();

            var x = _context
            .Pessas
            .Find(_ => true)
            .ToListAsync();

            var t = _context
            .Pessas
            .AsQueryable()
            .Select(expression)
            .ToListAsync();

            return await t;
        }

        public async Task CreateAsync()
        {
            PessoaDto pessoa = new()
            {
                Nome = "xxx"
            };

            await _context
            .Pessas.InsertOneAsync(pessoa);
        }
    }
}
