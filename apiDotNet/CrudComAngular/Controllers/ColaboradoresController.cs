using System.Threading.Tasks;
using CrudComAngular.Interfaces;
using CrudComAngular.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudComAngular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradoresController : ControllerBase
    {
        // 1. Injetamos a interface do SERVICE, e não mais o banco de dados!
        private readonly IColaboradorService _colaboradorService;

        public ColaboradoresController(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        [HttpPost]
        public async Task<IActionResult> AddColaborador(Colaborador colaborador)
        {
            var novoColaborador = await _colaboradorService.AddAsync(colaborador);
            return Ok(novoColaborador);
        }

        [HttpGet]
        public async Task<IActionResult> GetColaboradores()
        {
            var colaboradores = await _colaboradorService.GetAllAsync();
            return Ok(colaboradores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColaboradorById(int id)
        {
           
            var colaborador = await _colaboradorService.GetByIdAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            return Ok(colaborador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColaborador(int id, Colaborador colaborador)
        {
            // Toda a lógica de verificar se existe foi para o Service
            var colaboradorAtualizado = await _colaboradorService.UpdateAsync(id, colaborador);
            if (colaboradorAtualizado == null)
            {
                return NotFound();
            }
            return Ok(colaboradorAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColaborador(int id)
        {
            // O Service nos retorna true se deletou, e false se não achou o ID
            var sucesso = await _colaboradorService.DeleteAsync(id);
            if (!sucesso)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}