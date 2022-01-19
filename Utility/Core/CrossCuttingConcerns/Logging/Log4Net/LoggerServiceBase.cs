using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Castle.Core.Logging;
using Core.Extensions;
using log4net;
using log4net.Repository;
using log4net.Util;


namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerServiceBase
    {
        private ILog _log;
        public LoggerServiceBase(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(File.OpenRead("log4net.config"));
            ILoggerRepository logggeRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(logggeRepository, xmlDocument["log4net"]);
            _log = LogManager.GetLogger(logggeRepository.Name, name);
        }

        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;
        public void Info(LogDetail logMessage)
        {
            if (IsInfoEnabled)
                _log.Info(logMessage);

        }

        public void Debug(LogDetail logMessage)
        {
            if (IsDebugEnabled)
                _log.Debug(logMessage);

        }

        public void Warn(LogDetail logMessage)
        {
            if (IsWarnEnabled)
                _log.Warn(logMessage);

        }

        public void Fatal(LogDetail logMessage)
        {
            if (IsFatalEnabled)
                _log.Fatal(logMessage);

        }

        public void Error(LogDetailWithException logMessage)
        {
            //buraya birde mail gonderim ekleyelim.
            if (IsErrorEnabled)
                _log.Error(logMessage);



        }
    }

}
