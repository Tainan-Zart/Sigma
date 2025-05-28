using Microsoft.EntityFrameworkCore;
using Sigma.Domain.Entities;
using Sigma.Domain.Enums;
using Sigma.Domain.Interfaces.Repositories;
using Sigma.Infra.Data.Context;

namespace Sigma.Infra.Data.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly SigmaContext _dbContext;

        public ProjetoRepository(SigmaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Inserir(Projeto entity)
        {
           await _dbContext.Set<Projeto>().AddAsync(entity);
           await _dbContext.SaveChangesAsync();
           return true;
        }

        public async Task<List<Projeto>> Buscar(string login)
        {
            return await _dbContext.Projetos.Where(c => c.Usuario.Login == login).ToListAsync();
        }

        public async Task<Projeto?> BuscarPorNomeStatus(string nome, StatusProjetoEnum status, string loginUsuario)
        {
            return await _dbContext.Projetos.FirstOrDefaultAsync(c => c.Nome == nome && c.Status == status && c.Usuario.Login == loginUsuario);
        }

     
        public async Task<bool> Atualizar(Projeto entity)
        {
            _dbContext.Projetos.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Deletar(Projeto entity)
        {
            _dbContext.Projetos.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Projeto?> BuscarPorId(long id, string loginUsuario)
        {
            return await _dbContext.Set<Projeto>().FirstOrDefaultAsync(c => c.Id == id && c.Usuario.Login == loginUsuario);
        }
    }
}
