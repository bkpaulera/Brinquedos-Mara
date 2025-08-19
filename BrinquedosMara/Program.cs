using BrinquedosMara.API.Common;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configura��o geral
        builder.AddAppConfiguration();

        // Servi�os e reposit�rios
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
