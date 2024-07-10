using MechaSync.Domain;

namespace MechaSync.Services.Interfaces
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> GetAllAsync();
        Task<Service> GetByIdAsync(int id);
        Task InsertAsync(Service service);
        Task UpdateAsync(Service service);
        Task DeleteAsync(int id);
        Task<IEnumerable<Service>> GetByUserIdAsync(int userId);
    }
}