using System.ComponentModel.DataAnnotations;

namespace GuardianGrid.AdminPanel.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required]
        public string Regiao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataOcorrencia { get; set; }

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }

        public bool ZonaCritica { get; set; }
    }
}
