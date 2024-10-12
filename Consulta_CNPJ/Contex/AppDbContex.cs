using Microsoft.EntityFrameworkCore;

namespace Consulta_CNPJ.Models
{
    public class Context_CNPJ : DbContext
    {
        public Context_CNPJ(DbContextOptions<Context_CNPJ> options) : base(options)
        {
        }

        // O DbSet deve ser do tipo da entidade que você quer armazenar
        public DbSet<CNPJ_DADOS> CNPJ_DADOS { get; set; }
    }
}
