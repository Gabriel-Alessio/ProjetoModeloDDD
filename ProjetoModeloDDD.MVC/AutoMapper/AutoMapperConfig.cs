using AutoMapper;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
  public class AutoMapperConfig
  {
    public static MapperConfiguration ResgisterMappings()
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.AddProfile<ViewModelToDomainMappingProfile>();
        cfg.AddProfile<DomainToViewModelMappingProfile>();
      });
      return config;
    }
  }
}
