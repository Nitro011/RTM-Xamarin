using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models
{
    public class Almacen
    {
        [Key]
        public int Id { get; set; }
 
        public string NombreDelProducto { get; set; }
        public int? MateriaPrimaExistente { get; set; }
        public DateTime? Entrada { get; set; }

        [ForeignKey("suplidor")]
        public int IdSuplidor { get; set; }


        public Suplidor suplidor { get; set; }
    }
}
