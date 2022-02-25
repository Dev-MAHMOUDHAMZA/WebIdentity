using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebIdentity.Models;
using WebIdentity.ViewModels;

namespace WebIdentity.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<AppliactionUser> _userManager;
        private readonly SignInManager<AppliactionUser> _signInManager;

        public AccountsController(UserManager<AppliactionUser> userManager,
            SignInManager<AppliactionUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult List()
        {
            var UsersList = new RegisterListViewModel
            {
                Users = _userManager.Users.ToList()
            };
            return View(UsersList);
        }

        public IActionResult Registers()
        {       
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registers(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppliactionUser
                {
                    UserName = model.Email, 
                    Email=model.Email
                };
              var result= await _userManager.CreateAsync(user,model.Password);
                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index","Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }

        public async Task<IActionResult> Edit(string? Id)
        {
            var User =await _userManager.FindByIdAsync(Id);
            if(User == null)
            {
                return NotFound();
            }
            var UserEdit = new RegisterEditViewModel
            {
                Id = User.Id,
                Email =User.Email
            };
            return View(UserEdit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RegisterEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var User = await _userManager.FindByIdAsync(model.Id);
                User.Email = model.Email;
                User.Id = model.Id;
               var result= await _userManager.UpdateAsync(User);
                if (result.Succeeded)
                {
                    return RedirectToAction("List", "Accounts");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(string? Id)
        {
            var User = await _userManager.FindByIdAsync(Id);
            if (User == null)
            {
                return NotFound();
            }
            var UserEdit = new RegisterEditViewModel
            {
                Id = User.Id,
                Email = User.Email
            };
            return View(UserEdit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(RegisterEditViewModel model)
        {

            var user = _userManager.Users.FirstOrDefault(x=>x.Id == model.Id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("List", "Accounts");
                }
            }
            return View(model);
        }

    }
}
