using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace API.Controllers
{
    [Route("[controller]")]
    public class PaisController : BaseApiController
    {
        private readonly IUnitOfWorf unitofwork;

        public PaisController(IUnitOfWorf unitOfwork)
        {
            this.unitofwork = unitOfwork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Pais>>> Get()
        {
            var paises = await unitofwork.Paises.GetAllAsync();
            return Ok(paises);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Get(int id)
        {
            var paises = await unitofwork.Paises.GetByIdAsync(id);
            return Ok(paises);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Pais>> Post(Pais pais)
        {
            unitofwork.Paises.Add(pais);
            await unitofwork.SaveAsync();
            if(pais == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post),new {id = pais.Id},pais);
        }

        private ActionResult<Pais> CreatedAtaction(string v)
        {
            throw new NotImplementedException();
        }
    }
}