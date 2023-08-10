using Application.UserService.Interfaces;
using Domain.Model;

namespace Application.UserService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> CreateUser(CreateUserModel model)
        {
            var response = await _userRepository.CreateUser(model);
            return response;
        }

        public async Task<List<UserModel>> GetAllUser()
        {
            var response = await _userRepository.GetAllUser();
            return response;
        }

        public async Task<UserModel> GetUserById(Guid Id)
        {
            var response = await _userRepository.GetUserById(Id);
            return response;
        }

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            var response = await _userRepository.UpdateUser(user);
            return response;
        }
    }
}
