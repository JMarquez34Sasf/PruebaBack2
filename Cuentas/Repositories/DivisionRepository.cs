using Cuentas.Data;
using Cuentas.Interfaces;
using Cuentas.Models;
using Microsoft.EntityFrameworkCore;

namespace Cuentas.Repositories
{
    public class DivisionRepository:IDivision
    {
        private readonly CuentasDbContext context;
        public DivisionRepository(CuentasDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Division>> Get()
        {
            var division = await context.Divisions.ToListAsync();
            return division;
        }

        public async Task<Division?> GetById(int id)
        {
            var division = await context.Divisions
                .FindAsync(id);
            if (division == null) return null;
            return division;
        }
    }
}
