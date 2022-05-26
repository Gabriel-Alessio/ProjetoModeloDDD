using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
  public static class CustomMvcServiceCollectionExtensions
  {
    public static void AddAutoMapper(this IServiceCollection services)
    {
      if (services == null)
      {
        throw new ArgumentNullException(nameof(services));
      }
      var config = AutoMapperConfig.ResgisterMappings();
      IMapper mapper = config.CreateMapper();
      services.AddSingleton(mapper);
    }
  }
}
