﻿using Entidades.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interface.Equipo
{
    public interface IJugadorNegocio
    {
        Task<IList<Jugador>> GetJugadoresAsync();
        Task<Jugador> GetJugadorPorIdAsync(int id);
    }
}
