using GuessWeight.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuessWeight.Api.Context
{
    public class ConexaoDbContext : DbContext
    {
        public ConexaoDbContext(DbContextOptions<ConexaoDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UsuarioRespostaPeso> UsuarioRepostasPeso { get; set; }
    }
}
