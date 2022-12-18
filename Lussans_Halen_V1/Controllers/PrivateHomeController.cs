using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Lussans_Halen_V1.Models.ViewModels;
using Lussans_Halen_V1.Models;


namespace Lussans_Halen_V1.Controllers
{
   
    public class PrivateHomeController : Controller
    {
        private readonly UserManager<AccountPerson> _userManager;
        private readonly SignInManager<AccountPerson> _signInManager;

        public PrivateHomeController(UserManager<AccountPerson> userManager, SignInManager<AccountPerson> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult RegisterUser()
        {

            return View();
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterUser(CreateAccountPersonViewModel createAccount)
        {
            if (ModelState.IsValid)
            {
                AccountPerson accountPerson = new AccountPerson()
                {
                    UserName = createAccount.Username,
                    Email = createAccount.EMail,
                    FirstName = createAccount.FirstName,
                    LastName = createAccount.LastName,
                    DateOfBirth = createAccount.DateOfBirth,
                };

                IdentityResult result = await _userManager.CreateAsync(accountPerson, createAccount.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "PrivateHome");
                }

                foreach (IdentityError identityError in result.Errors)
                {
                    ModelState.AddModelError(identityError.Code, identityError.Description);
                }

            }

            return View();

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        async public Task<IActionResult> Login(string userName, string password)
        {
            Microsoft.AspNetCore.Identity.SignInResult result =
                await _signInManager.PasswordSignInAsync(userName, password, true, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }

}

