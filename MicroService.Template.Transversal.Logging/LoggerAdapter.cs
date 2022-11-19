using Microsoft.Extensions.Logging;
using MicroService.Template.Transversal.Common;
using WatchDog;

namespace MicroService.Template.Transversal.Logging
{
    public class LoggerAdapter<T>:IAppLogger<T>
    {
        private readonly ILogger _logger;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogInformation(string message, params object[] args) {
            _logger.LogInformation(message, args);
            WatchLogger.Log(message);
        }
        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
            WatchLogger.Log(message);
        }
        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
            WatchLogger.Log(message);
        }
    }
}