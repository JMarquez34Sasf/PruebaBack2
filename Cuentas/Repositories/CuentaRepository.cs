using Cuentas.Data;
using Cuentas.Interfaces;
using Cuentas.Models;
using Microsoft.EntityFrameworkCore;

namespace Cuentas.Repositories
{
    public class CuentaRepository: ICuenta
    {
        private readonly CuentasDbContext context;
        public CuentaRepository(CuentasDbContext context)
        {
            this.context = context;
        }

        public async Task<Cuenta> Create(Cuenta cuenta)
        {
            context.Cuentas.Add(cuenta);
            await context.SaveChangesAsync();
            return cuenta;
        }

        public async Task<List<Cuenta>> Get()
        {
            var cuentas = await context.Cuentas
                .Include(c=>c.IdDivisionNavigation)
                .Include(c=>c.IdMonedaNavigation)
                .ToListAsync();
            return cuentas;
                
        }
    }
}
