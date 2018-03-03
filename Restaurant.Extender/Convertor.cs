using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Extender
{
    public static class Convertor
    {

        /// <summary>
        /// Metoda de conversie catre tipul Short.
        /// </summary>
        /// <param name="objectToConvert">Obiectul trimis spre conversie</param>
        /// <returns>Obiectul convertit sau null in caz de eroare</returns>
        public static short? ToShort(this object objectToConvert)
        {
            short result;
            if (Int16.TryParse(objectToConvert.ToString(), out result))
                return result;
            else
                return null;
        }

        /// <summary>
        /// Metoda de conversie catre tipul Int.
        /// </summary>
        /// <param name="objectToConvert">Obiectul trimis spre conversie</param>
        /// <returns>Obiectul convertit sau null in caz de eroare</returns>
        public static int? ToInt(this object objectToConvert)
        {
            int result;
            if (Int32.TryParse(objectToConvert.ToString(), out result))
                return result;
            else
                return null;
        }

        /// <summary>
        /// Metoda de conversie catre tipul Long.
        /// </summary>
        /// <param name="objectToConvert">Obiectul trimis spre conversie</param>
        /// <returns>Obiectul convertit sau null in caz de eroare</returns>
        public static long? ToLong(this object objectToConvert)
        {
            long result;
            if (Int64.TryParse(objectToConvert.ToString(), out result))
                return result;
            else
                return null;
        }

        /// <summary>
        /// Metoda de conversie catre tipul Byte.
        /// </summary>
        /// <param name="objectToConvert">Obiectul trimis spre conversie</param>
        /// <returns>Obiectul convertit sau null in caz de eroare</returns>
        public static byte? ToByte(this object objectToConvert)
        {
            byte result;
            if (byte.TryParse(objectToConvert.ToString(), out result))
                return result;
            else
                return null;
        }

        /// <summary>
        /// Metoda de conversie catre tipul Decimal.
        /// </summary>
        /// <param name="objectToConvert">Obiectul trimis spre conversie</param>
        /// <returns>Obiectul convertit sau null in caz de eroare</returns>
        public static decimal? ToDecimal(this object objectToConvert)
        {
            decimal result;
            if (decimal.TryParse(objectToConvert.ToString(), out result))
                return result;
            else
                return null;
        }

        /// <summary>
        /// Metoda de conversie catre tipul Float.
        /// </summary>
        /// <param name="objectToConvert">Obiectul trimis spre conversie</param>
        /// <returns>Obiectul convertit sau null in caz de eroare</returns>
        public static float? ToFloat(this object objectToConvert)
        {
            float result;
            if (float.TryParse(objectToConvert.ToString(), out result))
                return result;
            else
                return null;
        }

        /// <summary>
        /// Metoda de conversie catre tipul Date.
        /// </summary>
        /// <param name="objectToConvert">Obiectul trimis spre conversie</param>
        /// <returns>Obiectul convertit sau null in caz de eroare</returns>
        public static DateTime? ToDate(this object objectToConvert)
        {
            DateTime result;
            if (DateTime.TryParse(objectToConvert.ToString(), out result))
                return result;
            else
                return null;
        }
    }
}
