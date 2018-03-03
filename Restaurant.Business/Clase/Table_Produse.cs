using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Business.Clase
{
  public class Table_Produse
    {
        public int Id_produs { get; set; }
        public string Nume_produs { get; set; }
        public int? Id_categorie { get; set; }
        public decimal? Pret { get; set; }
    }
}
