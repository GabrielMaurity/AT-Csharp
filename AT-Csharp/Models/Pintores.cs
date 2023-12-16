using System.ComponentModel.DataAnnotations;

namespace AT_Csharp.Models
{
    public class Pintores
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Name é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Description é obrigatório.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo anoNascimento é obrigatório.")]
        public int anoNascimento { get; set; }
    }
}
