using BrinquedosMara.API.Common;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configuração geral
        builder.AddAppConfiguration();

        // Serviços e repositórios
        builder.AddAppServices();

        // Swagger
        builder.AddSwaggerDocumentation();

        var app = builder.Build();

        // Pipeline
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
