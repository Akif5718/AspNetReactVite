using System;
using BH.Repositories;
using BH.Repositories.Connections;
using BH.Repositories.Connections.Interface;
using BH.Repositories.Interface;
using BH.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace BH.Services.Extensions
{
	public static class ManagersDependencyGroup
	{
        public static IServiceCollection AddManagersDependencyGroup(this IServiceCollection services)
		{
            // Connection
            services.AddTransient<IDbConnectionFactory, DapperConnectionFactory>();

            //Services
            services.AddTransient<IAccountService, AccountService>();

            //Repositories
            services.AddTransient<IAccountRepo, AccountRepo>();

            return services;
        }
	}
}

