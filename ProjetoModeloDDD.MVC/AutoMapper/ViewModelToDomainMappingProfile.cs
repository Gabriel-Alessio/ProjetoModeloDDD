using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
  public class ViewModelToDomainMappingProfile : Profile
  {
    public override string ProfileName
    {
      get { return "DomainToViewModelMappingProfile"; }
    } 

    public ViewModelToDomainMappingProfile()
    {
      CreateMap<Cliente, ClienteModel>();
      CreateMap<Produto, ProdutoModel>();
    }
  }
}
