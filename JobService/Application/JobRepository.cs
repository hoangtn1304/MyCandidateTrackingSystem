using JobService.Data;
using Microsoft.EntityFrameworkCore;

namespace JobService.Application
{
    public interface IJobRepository
    {
        Task<Domain.Job> GetByIdAsync(int id);
        Task<IEnumerable<Domain.Job>> GetAllAsync();
        Task AddAsync(Domain.Job entity);
        Task UpdateAsync(Domain.Job entity);
        Task DeleteAsync(int id);
    }

    public class JobRepository : IJobRepository
    {
        private readonly JobDbContext _context;

        public JobRepository(JobDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Job> GetByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Jobs.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<Domain.Job>> GetAllAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task AddAsync(Domain.Job entity)
        {
            await _context.Jobs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Job entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Jobs.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
