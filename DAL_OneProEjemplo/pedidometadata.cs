using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_OneProEjemplo
{
    [MetadataType(typeof(pedidoMetadata))]
    public partial class pedido { }

    public partial class pedidoMetadata
    {
        public int idPedido { get; set; }
        public Nullable<int> idCliente { get; set; }
        [Display(Name = "Fecha Time ")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public System.DateTime fechaTime { get; set; }
        public int idFabrica { get; set; }
    }
}
