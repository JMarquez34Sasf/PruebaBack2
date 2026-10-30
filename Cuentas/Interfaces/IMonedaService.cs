using Cuentas.Models;

namespace Cuentas.Interfaces
{
    public interface IMonedaService
    {
        Task<List<Monedum>> Get();
    }
}
