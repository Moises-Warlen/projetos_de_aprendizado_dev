using EmprestimosSMN.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimosSMN.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
      
        public DbSet<EmprestimoModel> Emprestimos { get; set; }
        public DbSet<UsuarioMoldel> Usuarios { get; set; }

    }
}
