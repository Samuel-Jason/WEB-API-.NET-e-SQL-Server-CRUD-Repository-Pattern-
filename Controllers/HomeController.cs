using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }

        [Route("api/[controller]")]
        [HttpGet]
        public async Task<IActionResult> GetAll(FuncionarioModel funcionario)
        {
            if (ModelState.IsValid)
            {
                var funcionarios = await funcionario.ObterFuncionarios();
                Console.WriteLine(funcionarios);
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddFuncionario(string nome, string idade)
        {
            var pessoa = new FuncionarioModel(nome, idade);

            var lista = await pessoa.ObterFuncionarios();
            lista.Add(pessoa);

            return Ok(pessoa);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] FuncionarioModel funcionario)
        {
            var funcionariosExistente = funcionario;

            funcionariosExistente.Nome = funcionario.Nome;
            funcionariosExistente.Idade = funcionario.Idade;

            return Ok(funcionariosExistente);
        }

        private async Task<IActionResult> ObterPorId(int id, [FromBody] FuncionarioModel funcionario)
        {
                var listaFuncionario = await funcionario.ObterFuncionarios();

                if (listaFuncionario.Any())
                {
                    return Ok(listaFuncionario.FirstOrDefault(x => x.Id == id));
                }

                return BadRequest("Objeto Funcionario nulo.");
        }
    }
}
