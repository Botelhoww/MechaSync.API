using MechaSync.Domain;
using MechaSync.Domain.Interface;
using MechaSync.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MechaSync.Infrastructure
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly MechaSyncDbContext _context;

        public ServiceRepository(MechaSyncDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetByUserIdAsync(int userId)
        {
            return await _context.Services
                .Where(s => s.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await _context.Services
                .ToListAsync();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _context.Services
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task InsertAsync(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
        }
    }
}