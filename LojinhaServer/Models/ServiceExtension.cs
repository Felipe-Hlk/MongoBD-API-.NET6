 using LojinhaServer.Models;
 using MongoDB.Driver;

 namespace LojinhaServer.Extensions;

 public static class ServiceExtensions
 {
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>{
            options.AddPolicy("Corspolicy",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );

        });
    }

 }

 public static void ConfigureMongoDBSettings(this IServiceCollection services, IConfiguration config)
 {
    services.ConfigureCors< MongoDBSettings >(
        config.GetSection("MongoDBSettings")
    );

    services.AddSingleton< IMOngoDatabase > (options =>{
        var settings = config.GetSection("MongoDBSettings")
            .Get<MongoDBSettings>();
        
        var client = new MongoClient( settings.ConnectionString );
        return client.GetDatabase(settings.DatabaseName); 

    });

 }