
using BH.Models;
using BH.Models.ViewModels;


namespace BH.Repositories.Interface
{
    public interface IUserRepo
    {
        Task<int> SaveUser(UserModel model);
        Task<ResultModel<UserModel>> GetUserById(int id);
        Task<ResultModel<List<UserModel>>> GetAllUser(UserListModel model);
        Task<ResultModel<int>> GetAllUserCount(UserListModel model);
    }
 }



