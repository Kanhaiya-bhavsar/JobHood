using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Infrastructure.Repositories;
using JobPortal.Domain.IRepository;
using JobPortal.Domain.Repositories;
using JobPortal.Infrastructure.Repositories;
using JobPortal.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobPortal.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext using connection string from configuration
            services.AddDbContext<JobPortalDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IJobRepository,JobRepository>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<ITokenRepository, TokenRepository>();

            return services;
        }
    }
}
