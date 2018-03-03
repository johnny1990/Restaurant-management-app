using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Restaurant.Extender;
using Restaurant.Business.Clase;

namespace Restaurant.Business.Operatii
{
   public static  class MonedaOperations
    {
        private const string My_SP = "Moneda";
        public static List<Table_Moneda> Get(string Id, string Nume_moneda)
        {
            List<SqlParameter> collection = new List<SqlParameter>();
            collection.Add(new SqlParameter("@Id", (object)Id));
            collection.Add(new SqlParameter("@Nume_moneda", (object)Nume_moneda));
            IDataReader reader = SQLDB.ExecuteGet(collection, My_SP);
            List<Table_Moneda> result = new List<Table_Moneda>();
            while (reader.Read())
            {
                Table_Moneda record = new Table_Moneda();
                record.Id = reader["Id"].ToInt().Value;
                record.Nume_moneda = reader["Nume_moneda"].ToString();
                result.Add(record);
            }
            return result;
        }
    }
}
