using AutoMapper;
using MFA.OHIO.BACK.Application.Interfaces;
using MFA.OHIO.BACK.Core.Repositories;
using MFA.OHIO.BACK.Infraestructure.Data;
using MFA.OHIO.BACK.Infraestructure.Repositories;
using MFA.OHIO.BACK.Infraestructure.Services.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Infraestructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<MFADbContext>(options => 
            {
                options.UseSqlServer(configuration.GetConnectionString("MFAOHIO") ?? 
                    throw new InvalidOperationException("connection string 'MFAOHIO' not found"));
            });

            services.AddTransient<IApplicationRepository, ApplicationRepository>();
            services.AddTransient<IAuditRepository, AuditRepository>();
            services.AddTransient<IGrantedUserRepository, GrantedUserRepository>(); 
            services.AddTransient<IPortalUserRepository, PortalUserRepository>();
            services.AddTransient<ITokenRepository, TokenRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();

            services.AddTransient<INotificationService, NotificationService>();

            return services;
        }
    }
}
