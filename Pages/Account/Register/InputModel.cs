// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;


namespace IdentityServerAspNetIdentity.Pages.Account.Register;

public class InputModel
{
    [Required(ErrorMessage = "�� ������� �������")]
    [Display(Name = "�������")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "�� ������� ���")]
    [Display(Name = "���")]
    public string Name { get; set; }

    [Required(ErrorMessage = "�� ������� ��������")]
    [Display(Name = "��������")]
    public string ParentName { get; set; }

    [MinLength(6,ErrorMessage ="����������� ����� ������ 6 ��������!")]        
    [Display(Name ="������")]
    [Required(ErrorMessage = "�� ������ ������")]
    public string Password { get; set; }   
    
    [EmailAddress(ErrorMessage = "������������ �����")]
    [Required(ErrorMessage = "�� ������ ����������� �����")]
    public string Email { get; set; }    
    public string ReturnUrl { get; set; }
    
}