using BH.Models;
using BH.Models.ViewModels;
using BH.Repositories;
using BH.Repositories.Interface;
using BH.Services.Interface;
using Microsoft.Extensions.Logging;

namespace BH.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserRepo> _logger;
        private readonly IUserRepo _repo;
        public UserService(ILogger<UserRepo> logger, IUserRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<ResultModel<UserModel>> SaveUser(UserModel model)
        {
            _logger.LogInformation("Going to execute Method: SaveUser, Class: UserService");
            var result = await _repo.SaveUser(model);
            _logger.LogInformation("Execution completed Method: SaveUser, Class: UserService");
            return await GetUserById(result);
        }

        public async Task<ResultModel<UserModel>> GetUserById(int id)
        {
            _logger.LogInformation("Going to execute Method: GetUserById, Class: UserService");
            var result = await _repo.GetUserById(id);
            _logger.LogInformation("Execution completed Method: GetUserById, Class: UserService");
            return result;
        }

        public async Task<ResultModel<List<UserModel>>> GetAllUser(UserListModel model)
        {
            _logger.LogInformation("Going to execute Method: GetAllUser, Class: UserService");
            var result = await _repo.GetAllUser(model);
            _logger.LogInformation("Execution completed Method: GetAllUser, Class: UserService");
            return result;
        }

        public async Task<ResultModel<int>> GetAllUserCount(UserListModel model)
        {
            _logger.LogInformation("Going to execute Method: GetAllUserCount, Class: UserService");
            var result = await _repo.GetAllUserCount(model);
            _logger.LogInformation("Execution completed Method: GetAllUserCount, Class: UserService");
            return result;
        }
    }
}


