using Microsoft.EntityFrameworkCore;

namespace GatePassApplicaation.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PreparedBy> preparedBy { get; set; }
        public DbSet<AuthorizedBy> authorizedBy { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Reasons> reasons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=DESKTOP-UBNQBT2\\SQLEXPRESS;Database=GatePassAppDb;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
