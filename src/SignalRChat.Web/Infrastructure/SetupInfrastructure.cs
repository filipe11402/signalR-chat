using SignalRChat.Web.Domain;

namespace SignalRChat.Web.Infrastructure;

public static class SetupInfrastructure
{
    public static void AddInfrastructureLayer(this IServiceCollection services) 
    {
        services.AddScoped<IMessageRepository, MessageRepository>();
    } 
}