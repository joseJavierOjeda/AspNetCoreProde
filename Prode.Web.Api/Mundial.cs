using Entidades.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prode.Web.Api
{
    public class Mundial
    {
        public List<Equipo> Equipos()
        {
            var lista = new List<Equipo>();

            lista.Add(new Equipo { EquipoId = 1, Nombre = "Jose", Codigo = "121212" });
            lista.Add(new Equipo { EquipoId = 2, Nombre = "Jose1", Codigo = "121212" });
            lista.Add(new Equipo { EquipoId = 3, Nombre = "Jose2", Codigo = "121212" });

            return lista;
        }
    }
}
