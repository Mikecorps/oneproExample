using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_OneProEjemplo
{
    [MetadataType(typeof(distribuidorMetadata))]
    public partial class distribuidor { }

    public partial class distribuidorMetadata
    {
        public int id { get; set; }
        [DisplayName("Fabrica")]
        public int idFabrica { get; set; }
        [Required(ErrorMessage = "Se requiere un nombre")]
        [DisplayName("Nombre")]
        public string nombreDistribuidor { get; set; }
        [Required(ErrorMessage = "El apellido paterno es obligatorio")]
        [DisplayName("Apellido Paterno")]
        public string apellidoPaterno { get; set; }
        [DisplayName ("Apellido Materno")]
        public string apellidoMaterno { get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Formato no valido(ejem: 999-999-9999).")]
        [DisplayName ("Telefono")]
        public string telefono { get; set; }
        [EmailAddress(ErrorMessage = "Ingrese un email valido")]
        [DisplayName ("Email")]
        public string email { get; set; }
    }
}
