using BH.Models;
using BH.Models.ViewModels;


namespace BH.Services.Interface
{
    public interface IUserService
    {
        Task<ResultModel<UserModel>> SaveUser(UserModel model);
        Task<ResultModel<UserModel>> GetUserById(int id);
        Task<ResultModel<List<UserModel>>> GetAllUser(UserListModel model);
        Task<ResultModel<int>> GetAllUserCount(UserListModel model);
    }
 }




