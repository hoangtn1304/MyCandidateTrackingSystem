namespace JobService.Application
{
    public interface IJobService
    {
        Task<Domain.Job> GetByIdAsync(int id);
        Task<IEnumerable<Domain.Job>> GetAllAsync();
        Task AddAsync(Domain.Job entity);
        Task UpdateAsync(Domain.Job entity);
        Task DeleteAsync(int id);
    }

    public class JobService : IJobService
    {
        private readonly IJobRepository _repository;

        public JobService(IJobRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Job> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Domain.Job>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(Domain.Job entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Domain.Job entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
