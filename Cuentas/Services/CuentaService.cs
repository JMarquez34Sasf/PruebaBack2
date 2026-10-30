using Cuentas.Interfaces;
using Cuentas.Models;

namespace Cuentas.Services
{
    public class CuentaService: ICuentaService
    {
        private readonly ICuenta repo;
        private readonly IMoneda repoMoneda;
        private readonly IDivision repoDivision;
        public CuentaService(ICuenta repo, IMoneda repoMoneda, IDivision repoDivision)
        {
            this.repo = repo;
            this.repoMoneda = repoMoneda;
            this.repoDivision = repoDivision;
        }

        public async Task<ResponseCuenta> CreateService(CreateCuenta dto)
        {
            var moneda = await repoMoneda.GetById(dto.IdMoneda);
            if (moneda == null) throw new ArgumentException("Moneda no existe");
            var division = await repoDivision.GetById(dto.IdDivision);
            if (division == null) throw new ArgumentException("Division no existe");
            var cuenta = new Cuenta
            {
                IdDivision = dto.IdDivision,
                IdMoneda = dto.IdMoneda,
                NumeroCuenta = dto.NumeroCuenta,
                Saldo = dto.Saldo,
            };
            var cuentaCreada = await repo.Create(cuenta);
            return new ResponseCuenta
            {
                IdCuenta = cuentaCreada.IdCuenta,
                NumeroCuenta = cuentaCreada.NumeroCuenta,
                Division = cuentaCreada.IdDivisionNavigation.Nombre,
                Moneda = cuentaCreada.IdMonedaNavigation.Nombre,
                Saldo = cuentaCreada.Saldo,
                FechaCreacion = cuentaCreada.FechaCreacion
            };
                
        }

        public async Task<List<ResponseCuenta>> GetService()
        {
            var cuentas = await repo.Get();
            return cuentas.Select(c => new ResponseCuenta
            {
                IdCuenta = c.IdCuenta,
                NumeroCuenta = c.NumeroCuenta,
                Division = c.IdDivisionNavigation.Nombre,
                Moneda = c.IdMonedaNavigation.Nombre,
                FechaCreacion = c.FechaCreacion,
                Saldo = c.Saldo
            }).ToList();
        }
    }
}
