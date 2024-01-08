using IdentityModel;
using IdentityServerAspNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerAspNetIdentity.Pages.Account.Register
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager                
            )
        {
           
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]        
        public InputModel Input { get; set; }   

        public async Task<IActionResult> OnGet(string returnUrl)
        {          
            
            Input = new InputModel
            {
                ReturnUrl = returnUrl
            };
            return Page();
        }

        public async Task<IActionResult> OnPost(string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = Input.Email,  
                    Email = Input.Email,
                    EmailConfirmed = true,
                    LastName = Input.LastName,
                    Name = Input.Name,
                    ParentName = Input.ParentName,
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                                  
                        await _userManager.AddClaimsAsync(user, new Claim[] {
                        new Claim(JwtClaimTypes.FamilyName,Input.LastName),
                        new Claim(JwtClaimTypes.Name,Input.Name),
                        new Claim(JwtClaimTypes.GivenName,Input.ParentName),
                        new Claim(JwtClaimTypes.Email,Input.Email)
                        
                    });

                    var loginresult = await _signInManager.PasswordSignInAsync(
                        Input.Email, Input.Password, false, lockoutOnFailure: true);

                    if (loginresult.Succeeded)
                    {
                        if (Url.IsLocalUrl(Input.ReturnUrl))
                        {
                            return Redirect(Input.ReturnUrl);
                        }
                        else if (string.IsNullOrEmpty(Input.ReturnUrl))
                        {
                            return Redirect("https://localhost:5004/");
                        }
                        else
                        {
                            throw new Exception("invalid return URL");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("Password","В пароле должна быть заглавная буква и спец символы #@!");
                }
            }
            return Page();        
    }
    }
}
