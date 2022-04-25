using WebApi.Controllers;
using WebApi.DataAccessors;

namespace WebApi
{
    public static class InjectionModule
    {
        public static IServiceProvider Register(IServiceCollection services)
        {
            services.AddSingleton<IRegisterDeviceAccessor, RegisterDeviceAccessor>();
            services.AddSingleton<RegisterDeviceController>();

            return services.BuildServiceProvider();
        }
    }
}
