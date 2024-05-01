using Microsoft.EntityFrameworkCore;

namespace Api_AngularCrud.Model
{
    public class CandidateDbContext : DbContext
    {

        public CandidateDbContext(DbContextOptions<CandidateDbContext> options) : base(options) { }
        public DbSet<Candidate> candidates { get; set; }
    }
}
