using System.ComponentModel.DataAnnotations;

namespace Questao1.Models
{
    public class Resultado
    {
        [Required(ErrorMessage = "CPF é obrigatório")]
        public string CPF { get; set; }

        public bool Aprovado { get; set; }
    }
}