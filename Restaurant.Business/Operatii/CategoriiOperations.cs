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
    public static class CategoriiOperations
    {
       private const string My_SP = "Categorii";
       public static List<Table_Categorii> Get(int? Id, string Nume_categorie)
        {
            List<SqlParameter> collection = new List<SqlParameter>();
            collection.Add(new SqlParameter("@Id", (object)Id));
            collection.Add(new SqlParameter("@Nume_categorie", (object)Nume_categorie));
            IDataReader reader = SQLDB.ExecuteGet(collection, My_SP);
            List<Table_Categorii> result = new List<Table_Categorii>();
            while (reader.Read())
            {
                Table_Categorii record = new Table_Categorii();
                record.Id = reader["Id"].ToInt().Value;
                record.Nume_categorie = reader["Nume_categorie"].ToString();
                result.Add(record);
            }
            return result;
        }

        public static List<Table_Categorii> Get_tot(int? Id, string Nume_categorie)
        {
            List<SqlParameter> collection = new List<SqlParameter>();
            collection.Add(new SqlParameter("@Id", (object)Id));
            collection.Add(new SqlParameter("@Nume_categorie", (object)Nume_categorie));
            IDataReader reader = SQLDB.ExecuteGet(collection, My_SP);
            List<Table_Categorii> result = new List<Table_Categorii>();
            while (reader.Read())
            {
                Table_Categorii record = new Table_Categorii();
                record.Id = reader["Id"].ToInt().Value;
                record.Nume_categorie = reader["Nume_categorie"].ToString();
                result.Add(record);
            }
            return result;
        }
        public static Table_Categorii Insert(this Table_Categorii obj)
        {
            List<SqlParameter> collection = new List<SqlParameter>();
            collection.Add(new SqlParameter("@Nume_categorie", (object)obj.Nume_categorie));
            SqlParameter par = new SqlParameter("@Id", SqlDbType.BigInt, sizeof(long));
            par.Direction = System.Data.ParameterDirection.Output;
            collection.Add(par);
            obj.Id = SQLDB.ExecuteInsert(collection, My_SP).ToInt().Value;
            return obj;
        }
        public static void Delete(int? Id)
        {
            List<SqlParameter> collection = new List<SqlParameter>();
            collection.Add(new SqlParameter("@Id", (object)Id));
            SQLDB.ExecuteDelete(collection, My_SP);
        }
        public static void Update(this Table_Categorii obj)
        {
            List<SqlParameter> collection = new List<SqlParameter>();
            collection.Add(new SqlParameter("@Id", (object)obj.Id));
            collection.Add(new SqlParameter("@Nume_categorie", (object)obj.Nume_categorie));   
            SQLDB.ExecuteUpdate(collection, My_SP);
        }
    }
}
