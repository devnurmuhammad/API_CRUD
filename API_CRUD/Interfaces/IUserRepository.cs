using API_CRUD.DTO;
using API_CRUD.Entities;

namespace API_CRUD.Interfaces
{
    public interface IUserRepository
    {
        public Task CreateUserAsync(UserDTO userDTO);
        public Task UpdateUserAsync(UserDTO userDTO, int age);
        public Task DeleteUserAsync(Guid Id);
        public Task<List<User>> GetAllUsersAsync();
    }
}
