using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddDbContext<MyDbContext>(
                options => options.UseCosmos(
                    "does not matter",
                    "does not matter"
                )
            )
            .AddControllers();

        var app = builder.Build();

        await RunAsync(app.Services);

        app.MapControllers();

        app.Run();
    }

    public static async Task RunAsync(IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();

            //MyModel myModel = new MyModel() { Data = new JArray() };

            await context.AddAsync(new JArray());
            //await context.MyModels.AddAsync(myModel);
        }
    }
}