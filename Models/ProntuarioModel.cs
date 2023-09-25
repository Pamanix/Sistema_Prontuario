using System.ComponentModel.DataAnnotations;

namespace Sistema_Prontuario.Models
{
    public class Prontuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo RG é obrigatório.")]
        public string RG { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public string Genero { get; set; }

        public string Peso { get; set; }

        public string Altura { get; set; }

        [Required(ErrorMessage = "O campo Diagnóstico é obrigatório.")]
        public string Diagnostico { get; set; }

        [Required(ErrorMessage = "O campo Tratamento é obrigatório.")]
        public string Tratamento { get; set; }

        [DataType(DataType.MultilineText)]
        public string Observacoes { get; set; }
    }
}

