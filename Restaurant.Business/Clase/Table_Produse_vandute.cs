using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Business.Clase
{
   public class Table_Produse_vandute
    {
        public int Id { get; set; }
        public int Id_factura { get; set; }
        public int Id_produs { get; set; }
        public string Nume_produs { get; set; }
        public decimal Pret { get; set; }
        public int Cantitate { get; set; }
        public decimal Valoare_totala { get; set; }
    }
}
