using Cuentas.Interfaces;
using Cuentas.Models;

namespace Cuentas.Services
{
    public class MonedaService: IMonedaService
    {
        private readonly IMoneda repo;
        public MonedaService(IMoneda repo)
        {
            this.repo = repo;
        }

        public async Task<List<Monedum>> Get()
        {
            var monedas = await repo.Get();
            return monedas;
        }

        public async Task<Monedum> GetById(int id)
        {
            var moneda = await repo.GetById(id);
            if (moneda == null) throw new ArgumentException("Moneda no exsite");
            return moneda;
        }
    }
}
