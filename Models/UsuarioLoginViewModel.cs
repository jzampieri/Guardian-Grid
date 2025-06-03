using System.ComponentModel.DataAnnotations;

namespace GuardianGrid.AdminPanel.Models
{
    public class UsuarioLoginViewModel
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
