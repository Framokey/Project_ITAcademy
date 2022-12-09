using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project_ITAcademy.Domain.ViewModels;


public class RegisterUserViewModel
{
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Укажите Email")]
    [MaxLength(50, ErrorMessage = "Email должен иметь длину меньше 50 символов")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Укажите имя")]
    [MaxLength(50)]
    [MinLength(2, ErrorMessage = "Имя должно иметь длину больше 2")]
    public string Name { get; set; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Укажите пароль")]
    [MinLength(5, ErrorMessage = "Пароль должен иметь длину больше 5")]
    public string Password { get; set; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Подтвердите пароль")]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string PasswordConfirm { get; set; }
    
}