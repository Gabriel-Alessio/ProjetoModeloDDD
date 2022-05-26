using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
  [AutoMap(typeof(Cliente), ReverseMap = true)]
  public class ClienteModel
  {
    [Key]
    public int ClienteId { get; set; }
    [Required(ErrorMessage = "Preencher o campo Nome")]
    [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
    [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]

    public string Nome { get; set; }
    [Required(ErrorMessage = "Preencher o campo Sobrenome")]
    [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
    [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
    public string Sobrenome { get; set; }

    [Required(ErrorMessage = "Preencher o campo E-mail")]
    [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
    [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
    [DisplayName("E-mail")]
    public string Email { get; set; }

    [ScaffoldColumn(false)]
    public DateTime DataCadastro { get; set; }

    public bool Ativo { get; set; }
    public virtual IEnumerable<ProdutoModel> Produtos { get; set; }
  }
}
