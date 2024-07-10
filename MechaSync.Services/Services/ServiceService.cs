using MechaSync.Domain;
using MechaSync.Domain.Interface;
using MechaSync.Infrastructure;
using MechaSync.Services.Interfaces;

namespace MechaSync.Services.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task DeleteAsync(int id)
        {
            await _serviceRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await _serviceRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Service>> GetByUserIdAsync(int userId)
        {
            return await _serviceRepository.GetByUserIdAsync(userId);
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _serviceRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Service service)
        {
            await _serviceRepository.InsertAsync(service);
        }

        public async Task UpdateAsync(Service service)
        {
            await _serviceRepository.UpdateAsync(service);
        }
    }
}