using Microsoft.EntityFrameworkCore;

namespace GuardianGrid.AdminPanel.Models
{
    public class GuardianGridContext : DbContext
    {
        public GuardianGridContext(DbContextOptions<GuardianGridContext> options)
            : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
    }
}
