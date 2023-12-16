using System.ComponentModel.DataAnnotations;

namespace AT_Csharp.Models
{
    public class Pintura
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string nome { get; set; }
        [Required(ErrorMessage = "O campo Autor é obrigatório.")]
        public string autor { get; set; }

        [Required(ErrorMessage = "O campo Data é obrigatório.")]
        public int data { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        public int valor { get; set; }

        [Required(ErrorMessage = "O campo Cores é obrigatório.")]
        public string cores { get; set; }

    }
}
