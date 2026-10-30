using Cuentas.Models;

namespace Cuentas.Interfaces
{
    public interface ICuenta
    {
        Task<List<Cuenta>> Get();
        Task<Cuenta> Create(Cuenta cuenta);
    }
}
