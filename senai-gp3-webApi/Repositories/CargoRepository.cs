using senai_gp3_webApi.Contexts;
using senai_gp3_webApi.Domains;
using senai_gp3_webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_gp3_webApi.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private readonly senaiRhContext ctx;

        public CargoRepository(senaiRhContext appContext)
        {
            ctx = appContext;
        }

        public void AtualizarCargo(int idCargo, Cargo cargoAtualizado)
        {
            throw new System.NotImplementedException();
        }

        public void CadastrarCargo(Cargo novoCargo)
        {
            throw new System.NotImplementedException();
        }

        public void DeletarCargo(int idCargo)
        {
            throw new System.NotImplementedException();
        }

        public Cargo ListarCargoPorId(int idCargo)
        {
            throw new System.NotImplementedException();
        }

        public List<Cargo> ListarCargos()
        {
            return ctx.Cargos.ToList();
        }
    }
}
