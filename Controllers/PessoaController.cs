using Controle_Escolar.Data.Dtos;
using Controle_Escolar.Services;
using Microsoft.AspNetCore.Mvc;


namespace Controle_Escolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            this.pessoaService = pessoaService;
        }

        [HttpGet("Login")]
        public async Task<ActionResult> Get([FromBody] string cpf, string senha)
        {
            return Ok(await pessoaService.Login(cpf, senha));
        }

        [HttpPost("cadastrar-usuario")]
        public async Task<ActionResult> Post([FromBody] PessoaDto pessoaDto)
        {
            await pessoaService.InsertPessoa(pessoaDto);

            return Ok();
        }
    }
}
