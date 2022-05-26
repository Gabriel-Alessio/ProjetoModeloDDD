using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
  public class DomainToViewModelMappingProfile : Profile
  {
    public override string ProfileName
    {
      get { return "ViewModeToDomainMappingProfile"; }
    } 
    public DomainToViewModelMappingProfile()
    {
      CreateMap<ClienteModel, Cliente>();
      CreateMap<ProdutoModel, Produto>();
    }
  }
}
