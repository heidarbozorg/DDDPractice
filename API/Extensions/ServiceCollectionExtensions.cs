using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private static string _dbName = "DDDPractice.db";
        private const string _connectionStringName = "CNS";


        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services,
            ConfigurationManager configuration = null)
        {
            return services.AddDbContext<EFContext>(options =>
                     //options.UseSqlite($"Data Source={GetSQLLiteFullPath()}")
                     //options.UseInMemoryDatabase(_dbName)
                     options.UseSqlServer(configuration.GetConnectionString(_connectionStringName))
            );
        }

        private static string GetSQLLiteFullPath()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var dbPath = Path.Combine(path, _dbName);
            return dbPath;
        }
    }
}
