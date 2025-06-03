using System.ComponentModel.DataAnnotations;

namespace GuardianGrid.AdminPanel.Models
{
    public class Alerta
    {
        public int Id { get; set; }

        [Required]
        public string RegiaoAfetada { get; set; }

        [Required]
        [StringLength(300)]
        public string Mensagem { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
