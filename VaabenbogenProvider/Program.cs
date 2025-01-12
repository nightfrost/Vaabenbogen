
using Microsoft.EntityFrameworkCore;
using VaabenbogenProvider.Data;
using VaabenbogenProvider.Controllers;

namespace VaabenbogenProvider
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<VaabenBogenContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("VaabenBogenConnection")));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapJaegerEndpoints();

            app.MapVaabenEndpoints();

            app.MapVirksomhedEndpoints();

            app.Run();
        }
    }
}
