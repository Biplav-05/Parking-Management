
using Domain.Model;
using System.Reflection;

namespace Application.UserService.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUser();
        Task<UserModel> GetUserById(Guid Id);
        Task<UserModel> UpdateUser(UserModel user);
        Task<string> CreateUser(CreateUserModel model);
    }
}
