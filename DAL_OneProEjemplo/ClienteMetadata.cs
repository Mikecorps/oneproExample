using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL_OneProEjemplo
{
    [MetadataType(typeof(ClienteMetadata))]
    public partial class Cliente { }
    public partial class ClienteMetadata
    {
        public int idCliente { get; set; }

        [Required(ErrorMessage = "Nombre de cliente requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "el apellido paterno es requerido")]
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public int genero { get; set; }
        [Required(ErrorMessage = "Ingrese fecha de nacimiento")]
        [Display(Name = "Fecha de Nacimiento:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fechaNac { get; set; }
        [EmailAddress(ErrorMessage = "Ingrese un email valido ")]
        public string email { get; set; }
        [Required(ErrorMessage ="Saldo es requerido")]
        [Range(0, float.MaxValue, ErrorMessage = "Cantidad no valida")]
        public float saldo { get; set; }
        [Range(0, 3000, ErrorMessage = "el limite de credito no debe exceder los 3000")]
        public decimal limiteCre { get; set; }
        [Range(0,100,ErrorMessage = "Descuento fuera del rago de porcentage")]
        public decimal descuento { get; set; }
    }
}
