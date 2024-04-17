using Controle_Escolar.Data.Dtos;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Controle_Escolar.Dao
{
    public interface IPessoaDao
    {
        Task<List<T?>> GetT<T>(Expression<Func<PessoaDto, T>> expression);
    }
}
