using Questao1.Models;

namespace Questao1.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        private static List<Jogador> jogadores = new List<Jogador>();

        private static List<Resultado> resultados = new List<Resultado>();


        public bool CadastrarJogador(Jogador jogador)
        {
            // Verifica se o CPF já existe
            bool cpfExiste = jogadores.Any(j => j.CPF == jogador.CPF);

            if (cpfExiste)
            {
                return false;
            }

            jogadores.Add(jogador);

            return true;
        }


        public List<Jogador> ListarJogadores()
        {
            return jogadores;
        }


        public bool RegistrarResultado(Resultado resultado)
        {

            bool jogadorExiste = jogadores.Any(j => j.CPF == resultado.CPF);

            if (!jogadorExiste)
            {
                return false;
            }


            bool resultadoExiste = resultados.Any(r => r.CPF == resultado.CPF);

            if (resultadoExiste)
            {
                return false;
            }

            resultados.Add(resultado);

            return true;
        }


        public List<Jogador> ListarAprovados()
        {
            var aprovados = jogadores
                .Where(j => resultados.Any(
                    r => r.CPF == j.CPF && r.Aprovado == true))
                .ToList();

            return aprovados;
        }
    }
}