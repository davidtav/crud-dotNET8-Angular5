using System.Collections.Generic;
using System.Threading.Tasks;
using CrudComAngular.Models;

namespace CrudComAngular.Interfaces;

public interface IColaboradorService
{
    Task<IEnumerable<Colaborador>> GetAllAsync();
    Task<Colaborador?> GetByIdAsync(int id);
    Task<Colaborador> AddAsync(Colaborador colaborador);
    
    Task<Colaborador?> UpdateAsync(int id, Colaborador colaborador);
    
    Task<bool> DeleteAsync(int id);
}