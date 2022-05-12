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
            services.AddSingleton<IDeviceAccessor, DeviceAccessor>();

            // Controllers
            services.AddSingleton<DeviceController>();
            services.AddSingleton<PositionUpdateController>();
            services.AddSingleton<FindController>();

            return services.BuildServiceProvider();
        }
    }
}
