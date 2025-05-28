using Microsoft.EntityFrameworkCore;
using Sigma.Domain.Entities;
using Sigma.Domain.Interfaces.Repositories;
using Sigma.Infra.Data.Context;

namespace Sigma.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly SigmaContext _context;

        public UsuarioRepository(SigmaContext context)
        {
            _context = context;
        }

        public async Task<bool> Inserir(Usuario cliente)
        {
            await _context.Usuarios.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario> BuscarPorLogin(string login)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(c => c.Login == login);
        }
    }
}
