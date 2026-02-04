using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoNaruto.Data;
using ProjetoNaruto.Models;

namespace ProjetoNaruto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PersonagensController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Get() => Ok("API funcionando");

        [HttpPost]
        public async Task<IActionResult> AddPersonagem(Personagem personagem)
        {
            // adiciona personagem ao banco
            _appDbContext.Naruto.Add(personagem);
            await _appDbContext.SaveChangesAsync();

            // retorna codigo positivo(200) mostrando o personagem adicionado
            return Ok(personagem);
        }
    }
}