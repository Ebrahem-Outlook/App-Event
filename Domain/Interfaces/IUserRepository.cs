using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    // Command 
    Task<bool> Create(User user);
    Task<bool> Update(User user);
    Task<bool> Delete(User user);

    // Query
    Task<List<User>> GetAll();
    Task<User> GetById(Guid id);
    Task<User> GetByEmail(string email);
}
