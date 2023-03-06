namespace ApplicationService.Application
{
    public interface IApplicationService
    {
        Task<Domain.Application> GetByIdAsync(int id);
        Task<IEnumerable<Domain.Application>> GetAllAsync();
        Task AddAsync(Domain.Application entity);
        Task UpdateAsync(Domain.Application entity);
        Task DeleteAsync(int id);
    }

    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _repository;

        public ApplicationService(IApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Application> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Domain.Application>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(Domain.Application entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Domain.Application entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
