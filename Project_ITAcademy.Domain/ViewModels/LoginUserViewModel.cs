using System.ComponentModel.DataAnnotations;

namespace Project_ITAcademy.Domain.ViewModels;

public class LoginUserViewModel
{
    [Required(ErrorMessage = "Введите имя")]
    [DataType(DataType.EmailAddress)]
    [MaxLength(50)]
    [MinLength(5)]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Введите пароль")]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; }
}