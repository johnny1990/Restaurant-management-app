using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Configurator
{
    public class ConfigurationSettings
    {
        #region Neutral Configuration
        public static string MainConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.Restaurant_DBConnectionString"].ConnectionString;
            }
        }
             public static string LabelPrefix
        {
            get
            {
                return ConfigurationManager.AppSettings["LabelPrefix"];
            }
        }
        public static string LabelPumpNumber
        {
            get
            {
                return ConfigurationManager.AppSettings["LabelPumpNumber"];
            }
        }
        public static string LogDirectory
        {
            get
            {
                return ConfigurationManager.AppSettings["LogDirectory"];
            }
        }
        public static string AsidDirectory
        {
            get
            {
                return ConfigurationManager.AppSettings["AsidDirectory"];
            }
        }
        public static string RptDirectory
        {
            get
            {
                return ConfigurationManager.AppSettings["RptDirectory"];
            }
        }
        public static string BackupDirectory
        {
            get
            {
                return ConfigurationManager.AppSettings["BackupDirectory"];
            }
        }
        public static string BackupTimer
        {
            get
            {
                return ConfigurationManager.AppSettings["BackupTimer"];
            }
        }
        public static string ScriptDirectory
        {
            get
            {
                return ConfigurationManager.AppSettings["ScriptDirectory"];
            }
        }
        public static bool ShowControlBox
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["ShowControlBox"]);
            }
        }
        public static string DefaultLanguage
        {
            get
            {
                return ConfigurationManager.AppSettings["DefaultLanguage"];
            }
            set
            {
                ConfigurationManager.AppSettings["DefaultLanguage"] = value;
            }
        }
        #endregion
    }
}

       
