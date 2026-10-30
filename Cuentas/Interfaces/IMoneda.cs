using Cuentas.Models;

namespace Cuentas.Interfaces
{
    public interface IMoneda
    {
        Task<List<Monedum>> Get();
        Task<Monedum> GetById(int id);
    }
}
