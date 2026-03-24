using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudComAngular.Data;
using Microsoft.AspNetCore.Mvc;
using CrudComAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudComAngular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradoresController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public ColaboradoresController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> AddColaborador(Colaborador colaborador)
        {
            _appDbContext.Colaboradores.Add(colaborador);
            await _appDbContext.SaveChangesAsync();
            return Ok(colaborador);
        }

        [HttpGet]
        public async Task<IActionResult> GetColaboradores()
        {
            
            var colaboradores = await _appDbContext.Colaboradores.ToListAsync();
            return Ok(colaboradores);
        }

        [HttpGet("{id}")]
        public IActionResult GetColaboradorById(int id)
        {
            var colaborador = _appDbContext.Colaboradores.FirstOrDefault(c => c.Id == id);
            if (colaborador == null)
            {
                return NotFound();
            }
            return Ok(colaborador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColaborador(int id, Colaborador colaborador)
        {
            var existingColaborador = _appDbContext.Colaboradores.FirstOrDefault(c => c.Id == id);
            if (existingColaborador == null)
            {
                return NotFound();
            }
            existingColaborador.Name = colaborador.Name;
            existingColaborador.Country = colaborador.Country;
            await _appDbContext.SaveChangesAsync();
            return Ok(existingColaborador);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColaborador(int id)
        {
            var colaborador = _appDbContext.Colaboradores.FirstOrDefault(c => c.Id == id);
            if (colaborador == null)
            {
                return NotFound();
            }
            _appDbContext.Colaboradores.Remove(colaborador);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}