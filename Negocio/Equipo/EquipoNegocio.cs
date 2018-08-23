using Datos.Interfaces.Equipo;
using Entidades.DB;
using Negocio.Interface.Equipo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Equipo
{
    public class EquipoNegocio : IEquipoNegocio
    {
        private readonly IEquipoRepository equipoRepository; 

        public EquipoNegocio(IEquipoRepository equipoRepository)
        {
            this.equipoRepository = equipoRepository;
        }

        public async Task<Entidades.DB.Equipo> GetEquipoPorId(int equipoId)
        {
            return await equipoRepository.GetEquipoPorId(equipoId);
        }
    }
}
