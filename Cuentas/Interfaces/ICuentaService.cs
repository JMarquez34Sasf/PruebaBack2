using Cuentas.Models;

namespace Cuentas.Interfaces
{
    public interface ICuentaService
    {
        Task<List<ResponseCuenta>> GetService();
        Task<ResponseCuenta> CreateService(CreateCuenta dto);
    }
}
