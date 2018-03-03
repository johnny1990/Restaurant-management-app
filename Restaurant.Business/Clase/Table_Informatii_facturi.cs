using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Business.Clase
{
    public class Table_Informatii_facturi
    {
        public int Id { get; set; }
        public string Nr_plata { get; set; }
        public DateTime Data_plata { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TVA_per { get; set; }
        public decimal Valoare_TVA { get; set; }
        public decimal Reducere_per { get; set; }
        public decimal Valoare_reducere { get; set; }
        public decimal Total_general { get; set; }
        public decimal Cash { get; set; }
        public decimal Change { get; set; }
        public string Opinii { get; set; }
        public int Id_moneda { get; set; }
        public int Id_restaurant { get; set; }

    }
}
