using Consulta_CNPJ.Models; // Certifique-se de incluir o namespace correto para o seu DbContext
using Microsoft.EntityFrameworkCore; // Necess�rio para o uso do DbContextOptions

namespace Consulta_CNPJ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adicione servi�os ao cont�iner.
            builder.Services.AddControllers();

            // Configurar Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Adicionar HttpClient
            builder.Services.AddHttpClient();

            // Registrar o DbContext
            builder.Services.AddDbContext<Context_CNPJ>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ajuste conforme sua string de conex�o

            var app = builder.Build();

            // Configurar o pipeline de requisi��es HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
