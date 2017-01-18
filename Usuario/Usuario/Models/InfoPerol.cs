using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Models
{
   public class InfoPerol
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

        public string Historia { get; set; }
        public string Telefono { get; set; }
        //  public string Pagina { get; set; }
        //  public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Horario { get; set; }
    }
}
