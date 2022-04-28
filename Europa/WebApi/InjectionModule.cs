using WebApi.Controllers;
using WebApi.DataAccessors;

namespace WebApi
{
    public static class InjectionModule
    {
        public static IServiceProvider Register(IServiceCollection services)
        {
            // Accessors
            services.AddSingleton<IFindAccessor, FindAccessor>();
            services.AddSingleton<IPositionUpdateAccessor, PositionUpdateAccessor>();
            services.AddSingleton<IRegisterDeviceAccessor, RegisterDeviceAccessor>();

            // Controllers
            services.AddSingleton<RegisterDeviceController>();
            services.AddSingleton<PositionUpdateController>();
            services.AddSingleton<FindController>();

            return services.BuildServiceProvider();
        }
    }
}
