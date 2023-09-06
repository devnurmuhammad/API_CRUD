using API_CRUD.DataContext;
using API_CRUD.DTO;
using API_CRUD.Entities;
using API_CRUD.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD.Services
{
    public class UserService : IUserRepository
    {
        public UserDbContext dbcontext;

        public UserService(UserDbContext userDbContext)
        {
            this.dbcontext = userDbContext;
        }
        public async Task CreateUserAsync(UserDTO userDTO)
        {
            var newuser = new User()
            {
                Id = Guid.NewGuid(),
                Name = userDTO.Name,
                Age = userDTO.Age,
            };
            await dbcontext.Users.AddAsync(newuser);
            await dbcontext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid Id)
        {
            var result = await dbcontext.Users.FirstOrDefaultAsync(x => x.Id == Id);
            if (result != null)
            {
                dbcontext.Users.Remove(result);
                await dbcontext.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var result = await dbcontext.Users.ToListAsync();
            return result;
        }

        public async Task UpdateUserAsync(UserDTO userDTO, int age)
        {
            var result = await dbcontext.Users.FirstOrDefaultAsync(i => i.Age == age);
            if (result != null)
            {
                result.Name = userDTO.Name;
                dbcontext.Users.Update(result);
                dbcontext.SaveChanges();
            }
        }
    }
}
