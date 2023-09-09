using Auth.Infrastructure.Repositories;
using Auth.UserAuth.Interfaces.Repositories;

namespace AuthApi.Configuration
{
    public static class Configuration
    {
        public static void RegisterRepositoriesScoped(this WebApplicationBuilder app)
        {
            app.Services.AddScoped<IUserServiceRepository, UserRepository>();
        }
    }
}
