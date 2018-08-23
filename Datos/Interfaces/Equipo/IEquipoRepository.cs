using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces.Equipo
{
    public interface IEquipoRepository
    {
        Task<Entidades.DB.Equipo> GetEquipoPorId(int equipoId);
    }
}
