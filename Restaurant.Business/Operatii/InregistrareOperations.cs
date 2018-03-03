using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
//using System.Extender;
using System.Threading.Tasks;
using Restaurant.Extender;
using Restaurant.Business.Clase;

namespace Restaurant.Business.Operatii
{
   public static class InregistrareOperations
    {
        private const string My_SP = "Inregistrare";
        public static List<Table_Inregistrare> Get(string Nume_utilizator, string Parola)
        {
            List<SqlParameter> collection = new List<SqlParameter>();
            collection.Add(new SqlParameter("@Nume_utilizator", (object)Nume_utilizator));
            collection.Add(new SqlParameter("@Parola", (object)Parola));
            IDataReader reader = SQLDB.ExecuteGet(collection, My_SP);
            List<Table_Inregistrare> result = new List<Table_Inregistrare>();
            while (reader.Read())
            {
                Table_Inregistrare record = new Table_Inregistrare();
                record.Nume_utilizator = reader["Nume_utilizator"].ToString();
                record.Parola = reader["Parola"].ToString().TrimEnd();
                result.Add(record);
            }
            return result;
        }
    }
}