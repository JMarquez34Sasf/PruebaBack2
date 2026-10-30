using Cuentas.Models;

namespace Cuentas.Interfaces
{
    public interface IDivisionService
    {
        Task<List<Division>> Get();
    }
}
