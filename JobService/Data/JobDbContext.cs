using JobService.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobService.Data
{
    public class JobDbContext : DbContext
    {
        public JobDbContext(DbContextOptions<JobDbContext> options) : base(options)
        {

        }

        public DbSet<Job> Jobs { get; set; }
    }
}
