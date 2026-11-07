using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RpgApi.Data;
using RpgApi.Models;
using RPGAPI.Models;

namespace RPGAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisputasController : ControllerBase
    {
        private readonly DataContext _context;

        public DisputasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("Arma")]
        public async Task<IActionResult> AtaqueComArmaAsync (Disputa d)
        {
            try
            {
                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Habilidade")]
        public async Task<IActionResult> AtaqueComHabilidade (Disputa d)
        {
            try
            {
                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("PersonagemRandom")]
        public async Task<IActionResult> Sorteio()
        {
            List<Personagem> personagens = await _context.TB_PERSONAGENS.ToListAsync();

            //sorteio com o numero da qtd de personagem
            int sorteio = new Random().Next(personagens.Count);

            //busca na lista pelo indice
            Personagem p = personagens[sorteio];

            string msg =
                string.Format("Número sorteado {0}, Personagem: {1}", sorteio, p.Nome);

            return Ok(msg);
        }

    }
}