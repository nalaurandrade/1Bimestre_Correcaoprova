using Microsoft.AspNetCore.Mvc;
using Questao1.Models;
using Questao1.Repositories;

namespace Questao1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogadoresController : ControllerBase
    {
        private readonly IJogadorRepository _repository;

        public JogadoresController(IJogadorRepository repository)
        {
            _repository = repository;
        }


        // POST: api/jogadores
        [HttpPost]
        public IActionResult Cadastrar(Jogador jogador)
        {
            // Verifica se a posição é válida
            string[] posicoesValidas =
            {
                "GL",
                "ZA",
                "LD",
                "LE",
                "VO",
                "MD",
                "AT"
            };

            if (!posicoesValidas.Contains(jogador.Posicao))
            {
                return BadRequest(
                    "Posição inválida. Use GL, ZA, LD, LE, VO, MD ou AT.");
            }

            // Tenta cadastrar
            bool cadastrado = _repository.CadastrarJogador(jogador);

            if (!cadastrado)
            {
                return BadRequest(
                    "Já existe um jogador cadastrado com esse CPF.");
            }

            return Ok("Jogador cadastrado com sucesso.");
        }


        // GET: api/jogadores
        [HttpGet]
        public IActionResult Listar()
        {
            var jogadores = _repository.ListarJogadores();

            return Ok(jogadores);
        }


        // POST: api/jogadores/resultado
        [HttpPost("resultado")]
        public IActionResult RegistrarResultado(Resultado resultado)
        {
            // Primeiro verifica se o jogador existe
            var jogadores = _repository.ListarJogadores();

            bool jogadorExiste = jogadores
                .Any(j => j.CPF == resultado.CPF);

            if (!jogadorExiste)
            {
                return NotFound(
                    "Jogador não encontrado. O resultado não pode ser registrado.");
            }

            // Tenta registrar
            bool registrado = _repository.RegistrarResultado(resultado);

            if (!registrado)
            {
                return BadRequest(
                    "O resultado desse jogador já foi registrado.");
            }

            return Ok("Resultado registrado com sucesso.");
        }


        // GET: api/jogadores/aprovados
        [HttpGet("aprovados")]
        public IActionResult ListarAprovados()
        {
            var aprovados = _repository.ListarAprovados();

            return Ok(aprovados);
        }
    }
}