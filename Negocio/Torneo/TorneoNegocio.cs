using Datos.Interfaces.Torneo;
using Entidades.DB;
using Negocio.Interface.Torneo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Torneo
{
    public class TorneoNegocio : ITorneoNegocio
    {
        private readonly ITorneoRepository torneoRepository;

        public TorneoNegocio(ITorneoRepository torneoRepository)
        {
            this.torneoRepository = torneoRepository;
        }

        public async Task<IList<Entidades.DB.Torneo>> GetTorneos()
        {
            return await torneoRepository.GetTorneos();
        }
    }
}
