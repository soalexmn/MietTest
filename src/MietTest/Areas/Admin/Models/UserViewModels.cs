
using DbLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MietTest.Areas.Admin.Models
{
  public class CreateModel
  {
    [Required]
    [Display(Name = "Имя пользователя")]
    public string Name { get; set; }
    [Required]

    [EmailAddress]
    [Display(Name = "Адрес электронной почты")]
    public string Email { get; set; }
    [Required]
    [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; }
  }

  
  public class RoleEditModel
  {
    public Role Role { get; set; }
    public IEnumerable<User> Members { get; set; }
    public IEnumerable<User> NonMembers { get; set; }
  }
  public class RoleModificationModel
  {
    [Required]
    public string RoleName { get; set; }
    public string[] IdsToAdd { get; set; }
    public string[] IdsToDelete { get; set; }
  }
}