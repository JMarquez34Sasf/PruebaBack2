using Cuentas.Models;

namespace Cuentas.Interfaces
{
    public interface IDivision
    {
        Task<List<Division>> Get();
        Task<Division?> GetById(int id);
    }
}
