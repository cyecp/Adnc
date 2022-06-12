using NLog;
using NLog.Web;

namespace Adnc.Usr.WebApi;

internal static class Program
{
    internal static async Task Main(string[] args)
    {
        var webApiAssembly = System.Reflection.Assembly.GetExecutingAssembly();
        var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
        logger.Debug($"init {nameof(Program.Main)}");
        try
        {
            //Configuration,ServiceCollection,Logging,WebHost(Kestrel)
            var builder = WebApplication.CreateBuilder(args);
            builder.ConfigureAdncDefault(args, webApiAssembly);

            var app = builder.Build();

            //Middlewares
            app.UseAdncDefault(endpointRoute: endpoint =>
            {
                endpoint.MapGrpcService<Grpc.AuthGrpcServer>();
                endpoint.MapGrpcService<Grpc.UsrGrpcServer>();
            });
            app.UseRegistrationCenter();

            //Start
            await app.ChangeThreadPoolSettings().RunAsync();
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Stopped program because of exception");
            throw;
        }
        finally
        {
            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            LogManager.Shutdown();
        }
    }
}