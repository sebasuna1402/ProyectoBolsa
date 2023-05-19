using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.IServices;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICandidatoService, CandidatoService>();//revisado
           
            services.AddScoped<IEntradaHabilidadCaService, EntradaHabilidadCaService>();//revisado
            
            services.AddScoped<IEntradaOferCaService, EntradaOferCaService>();//revisado


            services.AddScoped<IEntradaOfeHabService, EntradaOfeHabService>();//revisado
          
            services.AddScoped<IHabilidadService, HabilidadService>();// revisado
           
            services.AddScoped<IFormacionService, FormacionService>();// revisado
           
            services.AddScoped<IOfertaService, OfertaService>();// revisado
           
            services.AddScoped<IEmpresaService, EmpresaService>(); //revisado


            return services;
        }
    }
}


