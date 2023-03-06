using ApplicationService.Data;
using Microsoft.EntityFrameworkCore;

namespace ApplicationService.Application
{
    public interface IApplicationRepository
    {
        Task<Domain.Application> GetByIdAsync(int id);
        Task<IEnumerable<Domain.Application>> GetAllAsync();
        Task AddAsync(Domain.Application entity);
        Task UpdateAsync(Domain.Application entity);
        Task DeleteAsync(int id);
    }

    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Application> GetByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Applications.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<Domain.Application>> GetAllAsync()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task AddAsync(Domain.Application entity)
        {
            await _context.Applications.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Application entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Applications.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
