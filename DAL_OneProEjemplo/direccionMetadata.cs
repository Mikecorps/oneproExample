using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_OneProEjemplo
{
    [MetadataType(typeof(direccionMetadata))]
    public partial class Direccion { }
    public partial class direccionMetadata
    {
        public int idDireccion { get; set; }
        public int idCliente { get; set; }
        [Required(ErrorMessage =" Se requiere una direccion")]
        [DisplayName("Direccion")]
        public string direccion1 { get; set; }
    }
}
