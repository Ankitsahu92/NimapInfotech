using Microsoft.EntityFrameworkCore;
using NimapInfotech.Entity;

namespace NimapInfotech
{
    public static class AddServiceDependency
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
            //services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IUserRepository, UserRepository>();

            //services.AddTransient<IEmployeeService, EmployeeService>();
            //services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddDbContext<NimapInfotechContext>(db => db.UseSqlServer(configuration.GetConnectionString("DBConnectionStrings"))
                                                       // .EnableSensitiveDataLogging(true)
                                                       , ServiceLifetime.Scoped);
            //services.AddAutoMapper(typeof(AutoMapperRequestProfile));




        }
    }
}
