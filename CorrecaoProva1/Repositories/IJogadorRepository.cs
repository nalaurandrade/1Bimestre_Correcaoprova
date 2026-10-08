using Questao1.Models;

namespace Questao1.Repositories
{
    public interface IJogadorRepository
    {
        bool CadastrarJogador(Jogador jogador);

        List<Jogador> ListarJogadores();

        bool RegistrarResultado(Resultado resultado);

        List<Jogador> ListarAprovados();
    }
}