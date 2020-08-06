using log4net;
using log4net.Config;
using MessageAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MessageAPI.Logger
{
    /// <summary>
    /// Logger based on log4net
    /// </summary>
    public sealed class Logger : ILogger
    {
        private readonly ILog _errorLog;
        private readonly ILog _infoLog;
        public Logger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("Logger/log4net.config"));
            _errorLog = LogManager.GetLogger(Assembly.GetEntryAssembly(), "Error");
            _infoLog = LogManager.GetLogger(Assembly.GetEntryAssembly(), "Information");
        }

        public void Fatal(object message, Exception ex)
        {
            _errorLog.Fatal(message, ex);
        }

        public void Error(Exception exception)
        {
            _errorLog.Error(exception.Message, exception);
        }

        public void Error(string message)
        {
            _errorLog.Error(message);
        }

        public void Error(IEnumerable<Exception> exceptions)
        {
            foreach (var e in exceptions)
                _errorLog.Error(e.Message, e);
        }

        public void Error(string description, Exception exception)
        {
            _errorLog.Error(description, exception);
        }

        public void Information(string message)
        {
            _infoLog.Info(message);
        }
    }
}
