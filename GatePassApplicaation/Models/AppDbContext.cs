using Microsoft.EntityFrameworkCore;

namespace GatePassApplicaation.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PassHeader> passHeaders { get; set; }
        public DbSet<PassHeaderLead> passHeaderLeads { get; set; }
        public DbSet<PassHeaderAdmin> passHeaderAdmins { get; set; }
        public DbSet<PassNoteLead> passNoteLeads { get; set; }
        public DbSet<PassNote> passNotes { get; set; }
        public DbSet<PassNoteAdmin> passNoteAdmins { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Reasons> reasons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=DESKTOP-UBNQBT2\\SQLEXPRESS;Database=GatePassAppDb;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
