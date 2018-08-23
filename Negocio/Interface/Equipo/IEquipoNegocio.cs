using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interface.Equipo
{
    public interface IEquipoNegocio
    {
        Task<Entidades.DB.Equipo> GetEquipoPorId(int equipoId);
    }
}
