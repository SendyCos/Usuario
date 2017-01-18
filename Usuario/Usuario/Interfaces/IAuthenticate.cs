using System.Threading.Tasks;

namespace Usuario.Interfaces
{
    public interface IAuthenticate
    {
        Task<string> Authenticate();
    }
}