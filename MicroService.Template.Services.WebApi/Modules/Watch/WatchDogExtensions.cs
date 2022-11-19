using MicroService.Template.Transversal.Common.Constants;
using WatchDog;

namespace MicroService.Template.Services.WebApi.Modules.Watch
{
    public static class WatchDogExtensions
    {
        public static IServiceCollection AddWatchDog(this IServiceCollection services,IConfiguration configuration) {
            services.AddWatchDogServices(opt => {
                opt.SetExternalDbConnString = configuration.GetConnectionString(Variables.CONNECTION_STRING_NAME);
                opt.SqlDriverOption = WatchDog.src.Enums.WatchDogSqlDriverEnum.MSSQL;
                opt.IsAutoClear = true;
                opt.ClearTimeSchedule = WatchDog.src.Enums.WatchDogAutoClearScheduleEnum.Monthly;
            });
            
            return services;
        }
    }
}
