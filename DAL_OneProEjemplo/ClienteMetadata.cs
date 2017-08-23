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
        [DataType(DataType.EmailAddress,ErrorMessage ="Email no valido")]
        public string email { get; set; }
    }
}
