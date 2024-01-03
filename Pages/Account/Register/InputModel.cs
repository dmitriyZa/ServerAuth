// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;


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

    [MinLength(6,ErrorMessage ="Минимальная длина пароля 6 символов!")]        
    [Display(Name ="Пароль")]
    [Required(ErrorMessage = "Не указан пароль")]
    public string Password { get; set; }   
    
    [EmailAddress(ErrorMessage = "Некорректный адрес")]
    [Required(ErrorMessage = "Не указан электронный адрес")]
    public string Email { get; set; }    
    public string ReturnUrl { get; set; }
    
}