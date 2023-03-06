namespace CandidateService.Application
{
    public interface ICandidateService
    {
        Task<Domain.Candidate> GetByIdAsync(int id);
        Task<IEnumerable<Domain.Candidate>> GetAllAsync();
        Task AddAsync(Domain.Candidate entity);
        Task UpdateAsync(Domain.Candidate entity);
        Task DeleteAsync(int id);
    }

    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repository;

        public CandidateService(ICandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Candidate> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Domain.Candidate>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(Domain.Candidate entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Domain.Candidate entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
