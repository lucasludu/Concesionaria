using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace API.Middleware.Core.Logger
{
    public class LoggerCustom
    {
        private ILogger _logger;

        private string fileLocation = @"C:\Users\Lucaaas\Desktop\Programación\6 - Bootcamp\WebApiConcecionaria\logger.log";
        private string errorFileLoaction = @"C:\Users\Lucaaas\Desktop\Programación\6 - Bootcamp\WebApiConcecionaria\error.log";

        public LoggerCustom(ILogger logger)
        {
            _logger = logger;
        }

        public LoggerCustom()
        {

        }

        #region INFO
        public void Info(string message)
        {
            DateTime dateTime = DateTime.Now;
            message = String.Format(@"{0}: {1}", dateTime, message);
            if (_logger == null)
                Console.WriteLine(message);
            else
                _logger.LogInformation(message);
            using (var wr = File.AppendText(fileLocation))
            {
                wr.WriteLine(message);
            }
        }
        #endregion


        #region WARNING
        public void Warning(string message)
        {
            DateTime dateTime = DateTime.Now;
            message = String.Format(@"{0}: {1}", dateTime, message);

            if (_logger == null)
            {
                Console.WriteLine(message);
            }
            else
            {
                _logger.LogWarning(message);
            }

            using (var wr = File.AppendText(errorFileLoaction))
            {
                wr.WriteLine(message);
            }
        }
        #endregion


        #region ERROR
        public void Error(string message)
        {
            DateTime dateTime = DateTime.Now;
            message = String.Format(@"{0}: {1}", dateTime, message);

            if (_logger == null)
            {
                Console.WriteLine("Error " + message);
            }
            else
            {
                _logger.LogError(message);
            }

            using (var wr = File.AppendText(errorFileLoaction))
            {
                wr.WriteLine(message);
            }
        }
        #endregion

    }
}
