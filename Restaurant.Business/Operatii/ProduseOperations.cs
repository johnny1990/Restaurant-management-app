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
   public static class ProduseOperations
    {
        private const string My_SP = "Produse";
        public static List<Table_Produse> Get(string Nume_produs, string Pret)
        {
            List<SqlParameter> collection = new List<SqlParameter>();
            collection.Add(new SqlParameter("@Nume_produs", (object)Nume_produs));
            collection.Add(new SqlParameter("@Pret", (object)Pret));
            IDataReader reader = SQLDB.ExecuteGet(collection, My_SP);
            List<Table_Produse> result = new List<Table_Produse>();
            while (reader.Read())
            {
                Table_Produse record = new Table_Produse();
                record.Id_produs = reader["Id_produs"].ToInt().Value;
                record.Nume_produs = reader["Nume_produs"].ToString();
                record.Id_categorie = reader["Id_categorie"].ToInt();
                record.Pret = reader["Pret"].ToDecimal();
                result.Add(record);
            }
            return result;
        }
    }
}
