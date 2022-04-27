using WebApi.Controllers;
using WebApi.DataAccessors;

namespace WebApi
{
    public static class InjectionModule
    {
        public static IServiceProvider Register(IServiceCollection services)
        {
            // Accessors
            services.AddSingleton<IRegisterDeviceAccessor, RegisterDeviceAccessor>();
            services.AddSingleton<IPositionUpdateAccessor, PositionUpdateAccessor>();

            // Controllers
            services.AddSingleton<RegisterDeviceController>();
            services.AddSingleton<PositionUpdateController>();

            return services.BuildServiceProvider();
        }
    }
}
