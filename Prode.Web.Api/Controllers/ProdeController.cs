using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Prode.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdeController : ControllerBase
    {
        // GET api/values
        [Authorize]
        [HttpGet]
        public List<Equipo> Get()
        {

            var estaAutenticado = User.Identity.IsAuthenticated;

            if (estaAutenticado)
            {
                var mundial = new Mundial();

                return mundial.Equipos();
            }

            return new List<Equipo>();
        }
        
    }
}
