using System.ComponentModel.DataAnnotations;

namespace Questao1.Models
{
    public class Jogador
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Nome deve ter entre 3 e 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [StringLength(11, MinimumLength = 11,
            ErrorMessage = "CPF deve possuir 11 dígitos")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(500,
            ErrorMessage = "Descrição deve ter no máximo 500 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Posição é obrigatória")]
        public string Posicao { get; set; }
    }
}