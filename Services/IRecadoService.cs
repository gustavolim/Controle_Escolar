using Controle_Escolar.Data.Dtos;

namespace Controle_Escolar.Services
{
    public interface IRecadoService
    {
        Task CriarRecado(RecadoDto recadoDto);
        Task AlterarRecado(RecadoDto recadoDto);
        Task<List<RecadoDto>> ListRecados(DateTime? dtInicio, DateTime? dtFim);
        Task DeletarRecado(RecadoDto recadoDto);
    }
}
