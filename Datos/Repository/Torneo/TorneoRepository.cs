using Datos.Interfaces.Torneo;
using Entidades.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repository.Torneo
{
    public class TorneoRepository : ITorneoRepository
    {
        private readonly ProdeContext prodeContext;

        public TorneoRepository(ProdeContext prodeContext)
        {
            this.prodeContext = prodeContext;
        }

        public async Task<IList<Entidades.DB.Torneo>> GetTorneos()
        {
            return await prodeContext.Torneo.ToListAsync();
        }
    }
}
