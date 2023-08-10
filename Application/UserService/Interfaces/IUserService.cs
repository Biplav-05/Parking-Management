using Domain.Model;

namespace Application.UserService.Interfaces
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllUser();
        Task<UserModel> GetUserById(Guid Id);
        Task<UserModel> UpdateUser(UserModel user);
        Task<string> CreateUser(CreateUserModel model);
    }
}
