using System.Collections.Generic;
using System.Threading.Tasks;
using CrudComAngular.Models;

namespace CrudComAngular.Interfaces;

public interface IColaboradorRepository
{
    Task<IEnumerable<Colaborador>> GetAllAsync();
    
    // O '?' indica que pode retornar nulo caso o ID não exista
    Task<Colaborador?> GetByIdAsync(int id); 
    
    Task<Colaborador> AddAsync(Colaborador colaborador);
    
    Task<Colaborador> UpdateAsync(Colaborador colaborador);
    
    Task DeleteAsync(Colaborador colaborador);
}