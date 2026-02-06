using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoNaruto.Data;
using ProjetoNaruto.Models;
using Microsoft.EntityFrameworkCore;

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


        // async - torna o código assincrono com o banco = espera retorno do banco
        // await - faz a variavel esperar retorno do banco para executar o retante do codigo
        
        [HttpPost]
        public async Task<IActionResult> AddPersonagem(Personagem personagem)
        {
            // adiciona personagem ao banco
            _appDbContext.Naruto.Add(personagem);
            await _appDbContext.SaveChangesAsync();

            // retorna codigo positivo(200) mostrando o personagem adicionado
            return Ok(personagem);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagens()
        {
            // var espera receber lista do banco = _banco.nomedobanco.funcao
            var personagens = await _appDbContext.Naruto.ToListAsync();

            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personagem>> GetPersonagem(int id)
        {
            // var espera receber lista do banco = _banco.nomedobanco.funcao
            // faz a procura pelo id especifico
            var personagem = await _appDbContext.Naruto.FindAsync(id);

            if (personagem == null)
            {
                return NotFound("Personagem não encontrado");
            }

            return Ok(personagem);
        }

    }
}