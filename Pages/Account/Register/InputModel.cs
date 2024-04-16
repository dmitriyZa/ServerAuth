// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace IdentityServerAspNetIdentity.Pages.Account.Register;

public class InputModel
{
    [Required(ErrorMessage = "Не указана фамилия")]
    [Display(Name = "Фамилия")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Не указано имя")]
    [Display(Name = "Имя")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Не указано отчество")]
    [Display(Name = "Отчество")]
    public string ParentName { get; set; }

    [CustomPassword(ErrorMessage = "Некорректный пароль")]
    [MinLength(6,ErrorMessage ="Минимальная длина пароля 6 символов!")]        
    [Display(Name ="Пароль")]
    [Required(ErrorMessage = "Не указан пароль")]
    public string Password { get; set; }   
    
    [EmailAddress(ErrorMessage = "Некорректный адрес")]
    [Required(ErrorMessage = "Не указан электронный адрес")]
    public string Email { get; set; }    
    public string ReturnUrl { get; set; }
    
}

public class CustomPasswordAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        var password = value as string;
        if (password != null)
        {
            // Проверяем наличие хотя бы одной заглавной буквы
            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                ErrorMessage = "Пароль должен содержать хотя бы одну заглавную букву";
                return false;
            }

            // Проверяем наличие хотя бы одного из специальных символов #@!?
            if (!Regex.IsMatch(password, "[#@!?]"))
            {
                ErrorMessage = "Пароль должен содержать хотя бы один из специальных символов: #@!?";
                return false;
            }
        }
        return true;
    }
}