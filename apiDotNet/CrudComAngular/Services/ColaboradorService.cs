using System.Collections.Generic;
using System.Threading.Tasks;
using CrudComAngular.Interfaces;
using CrudComAngular.Models;


namespace CrudComAngular.Services
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<IEnumerable<Colaborador>> GetAllAsync()
        {
            return await _colaboradorRepository.GetAllAsync();
        }

        public async Task<Colaborador?> GetByIdAsync(int id)
        {
            return await _colaboradorRepository.GetByIdAsync(id);
        }

        public async Task<Colaborador> AddAsync(Colaborador colaborador)
        {
            return await _colaboradorRepository.AddAsync(colaborador);
        }

        public async Task<Colaborador?> UpdateAsync(int id, Colaborador colaborador)
        {
            var existingColaborador = await _colaboradorRepository.GetByIdAsync(id);
            if (existingColaborador == null)
                return null;

            existingColaborador.Name = colaborador.Name;            
            existingColaborador.Country = colaborador.Country;

            return await _colaboradorRepository.UpdateAsync(existingColaborador);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var colaborador = await _colaboradorRepository.GetByIdAsync(id);
            if (colaborador == null)
                return false;

            await _colaboradorRepository.DeleteAsync(colaborador);
            return true;
        }

    }
}