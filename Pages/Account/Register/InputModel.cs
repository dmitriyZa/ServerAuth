// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;


namespace IdentityServerAspNetIdentity.Pages.Account.Register;

public class InputModel
{
    [Required]
    [Display(Name = "���")]
    public string Name { get; set; }    

    [Required(), MinLength(6,ErrorMessage ="����������� ����� ������ 6 ��������!")]    
    [Display(Name ="������")]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    public string ReturnUrl { get; set; }
    
}