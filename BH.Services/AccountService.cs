using System;
using BH.Models;
using BH.Models.ResponseModels;
using BH.Models.ViewModels;
using BH.Repositories;
using BH.Repositories.Interface;
using BH.Services.Interface;
using Microsoft.Extensions.Logging;

namespace BH.Services
{
	public class AccountService:IAccountService
	{
        private readonly ILogger<AccountRepo> _logger;
        private readonly IAccountRepo _accountRepo;
        public AccountService(ILogger<AccountRepo> logger, IAccountRepo accountRepo)
		{
			_logger = logger;
            _accountRepo = accountRepo;
		}

        public async Task<ResultModel<bool>> IsUserNameUnique(string? userName)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultModel<bool>> RegisterUser(RegisterUserModel model)
        {
            _logger.LogInformation("Going to execute Method: RegisterUser, Class: AccountService");
            var result = await _accountRepo.RegisterUser(model);
            _logger.LogInformation("Execution completed Method: RegisterUser, Class: AccountService");
            return result;
        }
        
        public async Task<ResultModel<LoginResponse>> LoginUser(LoginUserModel model)
        {
            ResultModel<LoginResponse> result = new ResultModel<LoginResponse>();
            _logger.LogInformation("Going to execute Method: LoginUser, Class: AccountService");
            var resultLogin = await _accountRepo.LoginUser(model);
            if (!resultLogin.IsSuccess)
            {
                result.Message = resultLogin.Message;
                result.ErrorMessages = resultLogin.ErrorMessages;
                _logger.LogInformation("Execution completed Method: LoginUser, Class: AccountService");
                return result;
            }

            result.Data = new LoginResponse()
            {
                Token = await _accountRepo.GenerateToken(model)
            };
            result.IsSuccess = resultLogin.IsSuccess;
            result.Message = resultLogin.Message;
            _logger.LogInformation("Execution completed Method: LoginUser, Class: AccountService");
            return result;
        }
    }
}

