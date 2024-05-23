using Controle_Escolar.Data.Dtos;
using Controle_Escolar.Data.Repository;

namespace Controle_Escolar.Services
{
    public class RecadoService : IRecadoService
    {
        private readonly IMongoRepository<RecadoDto> repository;

        public RecadoService(IMongoRepository<RecadoDto> repository)
        {
            this.repository = repository;
        }

        public async Task AlterarRecado(RecadoDto recadoDto)
        {
            await repository.ReplaceOneAsync(recadoDto);
        }

        public async Task CriarRecado(RecadoDto recadoDto)
        {
            await repository.InsertOneAsync(recadoDto).ConfigureAwait(false);
        }

        public async Task DeletarRecado(RecadoDto recadoDto)
        {
            await repository.DeleteOneAsync(x=> x.Id == recadoDto.Id);
        }

        public async Task<List<RecadoDto>> ListRecados(DateTime? dtInicio, DateTime? dtFim)
        {
            if(dtInicio == null || (dtInicio == null || dtFim == null))
                return repository.FilterBy(x=> x.RecadoGeral != null).ToList();

            return repository.FilterBy(x=> x.DtCadastro >= dtInicio && (dtFim != null ? x.DtCadastro <= dtFim : x.DtCadastro <= DateTime.Now)).ToList();
        }
    }
}
