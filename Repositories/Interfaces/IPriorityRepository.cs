using System.Collections.Generic;
using System.Threading.Tasks;
using Taskmanager.Data.Entities;

namespace Taskmanager.Repositories.Interfaces
{
    public interface IPriorityRepository
    {
        public Task<Priority> GetByIdAsync(int priorityId);
        public Task<List<Priority>> GetAllAsync();
    }
}