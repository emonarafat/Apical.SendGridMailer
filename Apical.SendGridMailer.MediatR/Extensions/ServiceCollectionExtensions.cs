using Apical.SendGridMailer.MediatR.Interfaces;
using Apical.SendGridMailer.MediatR.Models;
using Apical.SendGridMailer.MediatR.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Apical.SendGridMailer;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// Provides extension methods for registering email-related services in the dependency injection container.
/// </summary>
public static class EmailServiceExtensions
{
    /// <summary>
    /// Registers email services, configuration, and MediatR handlers with the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    /// <param name="config">The application configuration containing email settings.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection AddEmailServices(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<EmailSettings>(config.GetSection("EmailSettings"));
        services.AddTransient<IEmailDispatcher, SendGridEmailSender>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EmailServiceExtensions).Assembly));
        return services;
    }
}

