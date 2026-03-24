using System.Collections.Generic;
using System.Threading.Tasks;
using CrudComAngular.Data;
using CrudComAngular.Interfaces;
using CrudComAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudComAngular.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly AppDbContext _appDbContext;

        // 1. Injeção do contexto do banco de dados no construtor
        public ColaboradorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Colaborador> AddAsync(Colaborador colaborador)
        {
            _appDbContext.Colaboradores.Add(colaborador);
            await _appDbContext.SaveChangesAsync();
            return colaborador;
        }

        public async Task DeleteAsync(Colaborador colaborador)
        {
            _appDbContext.Colaboradores.Remove(colaborador);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Colaborador>> GetAllAsync()
        {
            // O ToListAsync vai no banco, busca os dados e retorna como uma lista
            return await _appDbContext.Colaboradores.ToListAsync();
        }

        public async Task<Colaborador?> GetByIdAsync(int id)
        {
            return await _appDbContext.Colaboradores.FirstOrDefaultAsync(c => c.Id == id);
        }
        

        public async Task<Colaborador> UpdateAsync(Colaborador colaborador)
        {
            _appDbContext.Colaboradores.Update(colaborador);
            await _appDbContext.SaveChangesAsync();
            return colaborador;
        }
    }
}