using Cuentas.Interfaces;
using Cuentas.Models;

namespace Cuentas.Services
{
    public class DivisionService: IDivisionService
    {
        private readonly IDivision repo;
        public DivisionService(IDivision repo)
        {
            this.repo = repo;
        }

        public async Task<List<Division>> Get()
        {
            var divisiones = await repo.Get();
            return divisiones;
        }

        public async Task<Division?> GetById(int id)
        {
            var division = await repo.GetById(id);
            if (division == null) throw new ArgumentException("Division no existe");
            return division;
        }
    }
}
