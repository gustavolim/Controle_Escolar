using Controle_Escolar.Data.Dtos;
using Controle_Escolar.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Controle_Escolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecadoController : ControllerBase
    {
        private readonly IRecadoService recadoService;

        public RecadoController(IRecadoService recadoService)
        {
            this.recadoService = recadoService;
        }

        [HttpGet("Listar_Recados")]
        public async Task<ActionResult> Get([FromBody] DateTime? inicio, DateTime? fim)
        {
            return Ok(await recadoService.ListRecados(inicio,fim));
        }

        // GET api/<RecadoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost("Adicionar_Recado")]
        public async Task<ActionResult> Post([FromBody] RecadoDto recadoDto)
        {
            await recadoService.CriarRecado(recadoDto);

            return Ok();
        }

        [HttpPut("Editar_Recado")]
        public async Task<ActionResult> Put([FromBody] RecadoDto recadoDto)
        {
            await recadoService.AlterarRecado(recadoDto);

            return Ok();
        }

        
        [HttpDelete("Remover_Recado")]
        public async Task<ActionResult> Delete([FromBody] RecadoDto recadoDto)
        {
            await recadoService.DeletarRecado(recadoDto);

            return Ok();
        }
    }
}
