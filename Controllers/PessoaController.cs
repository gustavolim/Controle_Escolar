using Controle_Escolar.Data.Dtos;
using Controle_Escolar.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;


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
        public async Task<ActionResult> Get([FromQuery] string usuario, [FromQuery] string senha)
        {
            return Ok(await pessoaService.Login(usuario, senha));
        }

        [HttpGet("lista-usuario")]
        public async Task<ActionResult> GetListUsuario()
        {
            return Ok(await pessoaService.ListPessoas());
        }

        [HttpGet("lista-aluno")]
        public async Task<ActionResult> GetListAluno()
        {
            return Ok(await pessoaService.ListAluno());
        }

        [HttpGet("aluno-ra")]
        public async Task<ActionResult> GetAlunoRa([FromQuery] string alunoRA)
        {
            return Ok(await pessoaService.RetornaAlunoRa(alunoRA));
        }

        [HttpGet("lista-aluno-turma")]
        public async Task<ActionResult> GetListAlunoTurma([FromQuery] string turma)
        {
            return Ok(await pessoaService.RetornaAlunoTurma(turma));
        }

        [HttpPost("cadastrar-usuario")]
        public async Task<ActionResult> Post([FromBody] PessoaRequest pessoaDto, string senha)
        {
            if (senha != null)
                await pessoaService.InsertPessoa(pessoaDto, senha);

            return Ok();
        }

        [HttpPost("cadastrar-aluno")]
        public async Task<ActionResult> PostAluno([FromBody] CriancaDto alunoDto)
        {
            await pessoaService.InsertAluno(alunoDto);

            return Ok();
        }

        [HttpPut("editar-usuario")]
        public async Task<ActionResult<PessoaRequest>> EditarAluno([FromBody] PessoaRequest pessoaDto, string? senha)
        {
            if (!string.IsNullOrEmpty(senha))
            {
                await pessoaService.UpdatePessoa(pessoaDto, senha);
            }
            else
            {
                await pessoaService.UpdatePessoa(pessoaDto, null);
            }

            return Ok();
        }
    }
}
