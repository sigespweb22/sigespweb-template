using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Models;
using Sigesp.Domain.Interfaces;
using Sigesp.WebUI.Models;
using Sigesp.Infra.CrossCutting.Identity.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Sigesp.WebUI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly SmartSettings _smartSettings;
        private readonly IContaUsuarioRepository _contaUsuarioRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public LoginModel(UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager, 
                            ILogger<LoginModel> logger,
                            SmartSettings smartSettings,
                            IContaUsuarioRepository contaUsuarioRepository,
                            IMapper mapper,
                            UserResolverService userResolverService,
                            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _smartSettings = smartSettings;
            _contaUsuarioRepository = contaUsuarioRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger acocunt lockout, set lockoutOnFailure: true
                var result = await _signInManager
                                        .PasswordSignInAsync(Input.Email, 
                                                             Input.Password, 
                                                             Input.RememberMe, 
                                                             lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Usuário logado.");

                    #region Após logar usuário, colocar a TenantId na Session do usuário
                    Guid tenantId;
                    tenantId = _userManager.Users
                                        .Include(x => x.Tenant)
                                        .Where(x => x.Email.Equals(Input.Email))
                                        .FirstOrDefault().Tenant.Id;
                    
                    _session.SetString("TenantId", tenantId.ToString());
                    #endregion Após logar usuário, colocar a TenantId na Session do usuário

                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("Conta usuário bloqueada.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuário ou senha inválido (s).");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
