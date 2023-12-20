using System;
using BH.Models;
using BH.Models.ResponseModels;
using BH.Models.ViewModels;

namespace BH.Services.Interface
{
	public interface IAccountService
	{
        Task<ResultModel<bool>> RegisterUser(RegisterUserModel model);
        Task<ResultModel<bool>> IsUserNameUnique(string? userName);
        Task<ResultModel<LoginResponse>> LoginUser(LoginUserModel requestModel);
	}
}

