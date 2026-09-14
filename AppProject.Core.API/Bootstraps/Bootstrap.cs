using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Localization;

namespace AppProject.Core.API.Bootstraps;

public static class Bootstrap
{
    public static WebApplicationBuilder AddApiServices(this WebApplicationBuilder builder)
    {
        var mvcBuilder = builder.Services.AddControllers();

        ConfigureControllers(mvcBuilder);
        ConfigureLocalization(builder, mvcBuilder);
        return builder;
    }

    public static WebApplication UseApiPipeline(this WebApplication app)
    {
        app.UseRequestLocalization(); /* Configura a localização da aplicação com base nas opções definidas no ConfigureLocalization*/

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection(); /* Redireciona todas as requisições HTTP para HTTPS*/
        app.MapControllers(); /* Faz o mapeamento das rotas para os controllers da aplicação*/
        return app;
    }

    // Vai adicionar as controllers e configurar as opções de serialização JSON para a aplicação.
    private static void ConfigureControllers(this IMvcBuilder mvcBuilder)
    {
        // Percorrer todas as assemblies que contêm controllers e adicioná-las ao MVC Builder.
        foreach (var assembly in GetControllerAssemblies())
        {
            mvcBuilder.AddApplicationPart(assembly);
        }
    }

    private static IEnumerable<Assembly> GetControllerAssemblies() =>
    [
        Assembly.Load("AppProject.Core.Controllers"),
    ];

    private static void ConfigureLocalization(WebApplicationBuilder builder, IMvcBuilder mvcBuilder)
    {
        mvcBuilder.AddDataAnnotationsLocalization();
        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[] { "en-US", "pt-BR", "es-ES" };
            options.DefaultRequestCulture = new RequestCulture("en-US");
            options.SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
            options.SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
            options.RequestCultureProviders =
            [
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider(),
                new AcceptLanguageHeaderRequestCultureProvider()
            ];
        });
    }
}
