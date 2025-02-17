﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using vosplzen.sem1h3.Data.Model;

namespace vosplzen.sem1h3.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Student> _signInManager;
        private readonly UserManager<Student> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly RoleManager<Role> _rolemanager;

        public RegisterModel(
            UserManager<Student> userManager,
            SignInManager<Student> signInManager,
            ILogger<RegisterModel> logger,
            RoleManager<Role> rolemanager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _rolemanager = rolemanager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Class")]
            public string Class { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new Student { UserName = Input.Email, Email = Input.Email, Class = Input.Class };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userRoleExists = await _rolemanager.RoleExistsAsync("User");
                    if(!userRoleExists)
                    {
                        var role = new Role() { Name = "User" };
                        await _rolemanager.CreateAsync(role);
                    }

                    var adminRoleExists = await _rolemanager.RoleExistsAsync("Admin");
                    if (!userRoleExists)
                    {
                        var role = new Role() { Name = "Admin" };
                        await _rolemanager.CreateAsync(role);
                    }

                    var idResult = await _userManager.AddToRoleAsync(user, "User");

                    if(!idResult.Succeeded)
                    {
                        _logger.LogError(idResult.Errors.FirstOrDefault().Description);
                        throw new Exception("Role was not assigned!");

                     
                    }


                    await _signInManager.SignInAsync(user, isPersistent: false);                                     
                    return LocalRedirect(returnUrl);

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
