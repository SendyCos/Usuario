using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Models
{
   public class Promociones
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }
        public string Dia { get; set; }
        public string urlImagen { get; set; }
    }
}
