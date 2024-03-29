using Fetch.Service.Services;

namespace Fetch.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddGrpc();

            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //if (string.IsNullOrEmpty(connectionString))
            //{
            //    throw new InvalidOperationException("Database connection string 'DefaultConnection' not found.");
            //}
            //builder.Services.AddDbContext<FetchContext>(options =>
            //                options.UseNpgsql(connectionString));


            builder.Services.AddHttpClient();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.MapGrpcService<GrpcResturantService>();
            app.MapGrpcService<SandwichService>();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();

        }
    }
}