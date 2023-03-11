using MicroService.Template.Transversal.Common.Constants;
using WatchDog;

namespace MicroService.Template.Services.WebApi.Modules.Watch
{
    public static class WatchDogExtensions
    {
        public static IServiceCollection AddWatchDog(this IServiceCollection services,IConfiguration configuration) {
            services.AddWatchDogServices(opt => {
                opt.SetExternalDbConnString = configuration[Variables.CONNECTION_STRING_NAME];
                opt.DbDriverOption = WatchDog.src.Enums.WatchDogDbDriverEnum.MSSQL;
                opt.IsAutoClear = true;
                opt.ClearTimeSchedule = WatchDog.src.Enums.WatchDogAutoClearScheduleEnum.Monthly;
            });
            
            return services;
        }
    }
}
