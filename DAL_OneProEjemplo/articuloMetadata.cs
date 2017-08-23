using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_OneProEjemplo
{
    [MetadataType(typeof(articuloMetadata))]
    public partial class Articulo { }
    public partial class articuloMetadata
    {
        public int idArticulo { get; set; }
        [Required(ErrorMessage ="Cantidad del Articulo es requerida")]
        [Range(0,int.MaxValue,ErrorMessage ="Esta cantidad no es valida")]
        public int existencia { get; set; }
        [Required(ErrorMessage ="la descripcion del articulo es requerido")]
        public string descripcion { get; set; }
        [Required(ErrorMessage ="El costo es requerido")]
        [Range(0,double.MaxValue,ErrorMessage ="Esta Cantidad no es valida")]
        public Nullable<decimal> costo { get; set;}
        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "Esta Cantidad no es valida")]
        public Nullable<decimal> precioUnitario { get; set; }
        public Nullable<int> idFabrica { get; set; }
    }
}
