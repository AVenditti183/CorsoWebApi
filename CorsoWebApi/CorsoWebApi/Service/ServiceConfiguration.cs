using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsoWebApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CorsoWebApi.Service
{
    public static class ServiceConfiguration
    {
        public static void AddService(this IServiceCollection service)
        {
            service.AddScoped<IEFService<Evento>, EFService<Evento>>();
            service.AddScoped<EFBigliettoService > ();
            service.AddSingleton<BigliettoService>();
            service.AddScoped<IBigliettoService>(sp =>
                {
                    var configuration = sp.GetService<IConfiguration>();
                    var key = configuration["TipoImplementazione"];

                    if (key == "EF")
                        return (IBigliettoService) sp.GetService<EFBigliettoService>();
                    else
                    return (IBigliettoService)sp.GetService<BigliettoService>();
                });
        }
    }
}
