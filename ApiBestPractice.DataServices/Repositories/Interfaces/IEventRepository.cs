using ApiBestPractice.Entities.Entities;

namespace ApiBestPractice.DataServices.Repositories.Interfaces;

public interface IEventRepository : IGenericRepository<Event>
{ 
    Task<Event?> GetEvent(int id);
}