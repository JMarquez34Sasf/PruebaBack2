using Cuentas.Data;
using Cuentas.Interfaces;
using Cuentas.Models;
using Microsoft.EntityFrameworkCore;

namespace Cuentas.Repositories
{
    public class MonedaRepository:IMoneda
    {
        private readonly CuentasDbContext context;
        public MonedaRepository(CuentasDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Monedum>> Get()
        {
            var monedas = await context.Moneda.ToListAsync();
            return monedas;
        }

        public async Task<Monedum> GetById(int id)
        {
            var moneda = await context.Moneda.FindAsync(id);
            if (moneda == null) return null;
            return moneda;
        }
    }
}
