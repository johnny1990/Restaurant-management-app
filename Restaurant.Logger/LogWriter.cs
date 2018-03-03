using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Logger
{
   public static class LogWriter
    {
        /// <summary>
        /// Stocheaza inregistrarea primita in directorul de inregistrari.
        /// </summary>
        private static void Write(this Log log)
        {
            log.Date = DateTime.Now;

            StreamWriter sw = new StreamWriter(Configurator.ConfigurationSettings.LogDirectory + DateTime.Today.ToString("yyyy.MM.dd") + ".txt", true);
            StringBuilder sb = new StringBuilder();
            sb.Append(log.Date + " >>> ");
            sb.Append("[" + log.Type + "] ");
            sb.Append(log.CustomMessage);
            if (!String.IsNullOrEmpty(log.SourceMessage))
                sb.Append(" >>> " + log.SourceMessage);
            sw.WriteLine(sb.ToString());
            sw.Close();
        }

        /// <summary>
        /// Creeaza o noua inregistrare informativa si apeleaza metoda Write.
        /// </summary>
        public static void LogInfo(string customMessage)
        {
            Log log = new Log();
            log.Type = LogType.INFO;
            log.CustomMessage = customMessage;
            log.Write();
        }

        /// <summary>
        /// Creeaza o noua inregistrare continand un mesaj si apeleaza metoda Write.
        /// </summary>
        /// <param name="type">Tipul inregistrarii</param>
        /// <param name="customMessage">Mesajul de stocat in inregistrare</param>
        /// <param name="sourceMessage">Sursa mesajului</param>
        public static void LogCustomMessage(LogType type, string customMessage, string sourceMessage)
        {
            Log log = new Log();
            log.Type = type;
            log.CustomMessage = customMessage;
            log.SourceMessage = sourceMessage;
            log.Write();
        }

        /// <summary>
        /// Creeaza o noua inregistrare continand o exceptie si apeleaza metoda Write.
        /// </summary>
        /// <param name="exception">Exceptia de stoacat in inregistrare</param>
        public static void LogException(Exception exception)
        {
            Log log = new Log();
            log.Type = LogType.ERR;
            log.CustomMessage = exception.ToString();
            log.Write();
        }
    }
}

