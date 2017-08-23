using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_OneProEjemplo
{
    [MetadataType(typeof(FabricaMetadata))]
    public partial class Fabricas { }
    public partial class FabricaMetadata
    {
        public int idFabrica { get; set; }
        [Required(ErrorMessage ="Se requiere un nombre")]
        public string nombre { get; set; }
        public string descripcion { get; set; }
        [Required(ErrorMessage = "Se requiere un telefono")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Formato no valido(ejem: 999-999-9999).")]
        public string telefono { get; set; }
    }
}
