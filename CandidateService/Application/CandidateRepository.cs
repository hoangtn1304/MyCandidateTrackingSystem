using CandidateService.Data;
using Microsoft.EntityFrameworkCore;

namespace CandidateService.Application
{
    public interface ICandidateRepository
    {
        Task<Domain.Candidate> GetByIdAsync(int id);
        Task<IEnumerable<Domain.Candidate>> GetAllAsync();
        Task AddAsync(Domain.Candidate entity);
        Task UpdateAsync(Domain.Candidate entity);
        Task DeleteAsync(int id);
    }

    public class CandidateRepository : ICandidateRepository
    {
        private readonly CandidateDbContext _context;

        public CandidateRepository(CandidateDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Candidate> GetByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Candidates.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<Domain.Candidate>> GetAllAsync()
        {
            return await _context.Candidates.ToListAsync();
        }

        public async Task AddAsync(Domain.Candidate entity)
        {
            await _context.Candidates.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Candidate entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Candidates.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
