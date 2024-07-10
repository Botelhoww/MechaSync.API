namespace MechaSync.Domain.Interface
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllAsync();
        Task<Service> GetByIdAsync(int id);
        Task InsertAsync(Service service);
        Task UpdateAsync(Service service);
        Task DeleteAsync(int id);

        Task<IEnumerable<Service>> GetByUserIdAsync(int userId);

    }
}