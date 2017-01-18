using System.Collections.Generic;
using System.Threading.Tasks;
using Usuario.Models;

namespace Usuario.Interfaces
{
    public interface IPlatilloService
    {
        Task<IEnumerable<Platillos>> ObtenerPlatillos();
    }
}