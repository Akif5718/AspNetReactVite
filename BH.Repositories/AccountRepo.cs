﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BH.Models;
using BH.Models.ViewModels;
using BH.Repositories.Connections;
using BH.Repositories.Connections.Interface;
using BH.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BH.Repositories
{
	public class AccountRepo:BHConnectionBase,IAccountRepo
	{
        private readonly ILogger<AccountRepo> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;
        public AccountRepo(IDbConnectionFactory dbConnectionFactory, ILogger<AccountRepo> logger,
            UserManager<IdentityUser> userManager, IConfiguration config)
			:base(dbConnectionFactory)
		{
			_logger = logger;
            _userManager = userManager;
            _config = config;
		}

        public async Task<ResultModel<bool>> IsUserNameUnique(string? userName)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultModel<bool>> RegisterUser(RegisterUserModel model)
        {
            ResultModel<bool> resultModel = new ResultModel<bool>();
            _logger.LogInformation("Going to execute Method: RegisterUser, Class: AccountRepo");
            try
            {
                //var isUniqueName = await IsUserNameUnique(model.UserName);

                //if (!isUniqueName.Data)
                //{
                //    throw new Exception("UserName is not unique");
                //}

                var identityUser = new IdentityUser()
                {
                    Email = model.Email,
                    UserName = model.UserName
                };
                var result = await _userManager.CreateAsync(identityUser, model.Password);
                if (result.Succeeded)
                {
                    resultModel.Data = true;
                    resultModel.Message = "User created successfully";
                    resultModel.IsSuccess = true;
                    _logger.LogInformation("Execution completed Method: RegisterUser, Class: AccountRepo");
                    return resultModel;
                }
                resultModel.Message = "User is not created";
                resultModel.ErrorMessages = result.Errors.Select(e => e.Description);
                return resultModel;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception occurred in Method: RegisterUser, Class: AccountRepo, error :{ex.Message}");
                resultModel.Message = "Something went wrong";
                resultModel.ErrorMessages = ex.Message.Split(Environment.NewLine);
                return resultModel;
            }
        }
        public async Task<ResultModel<bool>> LoginUser(LoginUserModel model)
        {
            ResultModel<bool> resultModel = new ResultModel<bool>();
            _logger.LogInformation("Going to execute Method: LoginUser, Class: AccountRepo");
            try
            {
                var identityUser = await _userManager.FindByEmailAsync(model.UserName) ?? await _userManager.FindByNameAsync(model.UserName);
                if (identityUser is null)
                {
                    resultModel.Message = "User is not found";
                    return resultModel;
                }
                
                resultModel.Data = await _userManager.CheckPasswordAsync(identityUser, model.Password);
                if (resultModel.Data)
                {
                    resultModel.Message = "Successfully authenticated";
                    resultModel.IsSuccess = true;
                    _logger.LogInformation("Execution completed Method: LoginUser, Class: AccountRepo");
                    return resultModel;
                }
                
                resultModel.Message = "Invalid User Name or Password";
                resultModel.IsSuccess = false;
                _logger.LogInformation("Execution completed Method: LoginUser, Class: AccountRepo");
                return resultModel;

            }
            catch (Exception ex)
            {
                resultModel.Message = "Something went wrong";
                resultModel.ErrorMessages = ex.Message.Split(Environment.NewLine);
                _logger.LogError($"Exception occurred in Method: LoginUser, Class: AccountRepo, error :{ex.Message}");
                return resultModel;
            }
        }

        public async Task<string> GenerateToken(LoginUserModel user)
        {
            // var claims = new List<Claim>
            // {
            //     new Claim(ClaimTypes.Email,user.UserName),
            //     new Claim(ClaimTypes.Role,"Admin"),
            // };
            _logger.LogInformation("Going to execute Method: GenerateToken, Class: AccountRepo");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
             //   claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            _logger.LogInformation("Execution completed Method: GenerateToken, Class: AccountRepo");
            return tokenString;
        }
    }
}

