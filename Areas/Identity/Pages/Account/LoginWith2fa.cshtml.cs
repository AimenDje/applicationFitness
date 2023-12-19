using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SuiviFitness.Services;
using Twilio.TwiML.Voice;

namespace SuiviFitness.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginWith2faModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<LoginWith2faModel> _logger;
        private readonly ISMSSenderService _smsSenderService;

        public LoginWith2faModel(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            ILogger<LoginWith2faModel> logger,
            ISMSSenderService sMSSenderService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _smsSenderService = sMSSenderService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(7, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Text)]
            [Display(Name = "Authenticator code")]
            public string TwoFactorCode { get; set; }

            [Display(Name = "Remember this machine")]
            public bool RememberMachine { get; set; }
            public string TwoFactAuthProviderName { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(bool rememberMe, string returnUrl = null)
        {
            // Assurez-vous que l'utilisateur a d'abord passé par l'écran de nom  d'utilisateur et de mot de passe
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new InvalidOperationException($"Impossible de charger l'utilisateur d'authentification à deux facteurs.");
            }
            // Récupère la liste des fournisseurs d'authentification à deux facteurs valides pour cet utilisateur
            var providers = await _userManager.GetValidTwoFactorProvidersAsync(user);
            Input = new InputModel(); // Crée une instance de la classe InputModel
                                      // Vérifie s'il y a un fournisseur d'authentification à deux facteurs de type "Phone"(téléphone)
            if (providers.Any(_ => _ == "Phone"))
            {
                // Configure le fournisseur actuel comme "Phone"
                Input.TwoFactAuthProviderName = "Phone";
                // Génère un jeton à deux facteurs pour le téléphone
                var token = await _userManager.GenerateTwoFactorTokenAsync(user,
               "Phone");
                // Envoie le jeton par SMS à l'utilisateur
                await _smsSenderService.SendSmsAsync(user.PhoneNumber, $"OTP Code: {token} ");
            }

            else
            {
                throw new InvalidOperationException($"Impossible de charger  l'utilisateur d'authentification à deux facteurs.");
            }
            // Configure les valeurs de retour pour la page
            ReturnUrl = returnUrl;
            RememberMe = rememberMe;
            // Renvoie la page actuelle
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(bool rememberMe, string returnUrl = null)
        {
            // Vérifie si le modèle (ModelState) est valide, c'est-à-dire s'il n'y  pas d'erreurs de validation
            if (!ModelState.IsValid)
            {
                return Page(); // Recharge la page actuelle si des erreurs de validation sont détectées
            }
            // Si returnUrl est nul, le remplace par l'URL par défaut
            returnUrl = returnUrl ?? Url.Content("~/");
            // Récupère l'utilisateur qui a passé par l'authentification à deux facteurs
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new InvalidOperationException($"Impossible de charger l'utilisateur d'authentification à deux facteurs.");
            }
            // Récupère le code d'authentification à deux facteurs de l'entrée (Input)  en supprimant les espaces et les tirets
            var authenticatorCode = Input.TwoFactorCode.Replace(" ",
            string.Empty).Replace("-", string.Empty);
            // Tente de valider le code d'authentification à deux facteurs en utilisant le gestionnaire d'authentification
            var result = await
            _signInManager.TwoFactorSignInAsync(Input.TwoFactAuthProviderName, authenticatorCode, rememberMe, Input.RememberMachine);
            // Récupère l'ID de l'utilisateur
            var userId = await _userManager.GetUserIdAsync(user);
            if (result.Succeeded)
            {
                // L'authentification à deux facteurs a réussi, enregistre un message de journalisation
                _logger.LogInformation("L'utilisateur avec l'ID '{UserId}' s'est connecté avec 2FA.", user.Id);
                // Redirige l'utilisateur vers l'URL de retour spécifiée
                return LocalRedirect(returnUrl);
            }
            else if (result.IsLockedOut)
            {
                // Le compte de l'utilisateur est verrouillé, enregistre un message de journalisation
                _logger.LogWarning("Le compte de l'utilisateur avec l'ID '{UserId}' est verrouillé.", user.Id);
                // Redirige l'utilisateur vers une page de verrouillage de compte
                return RedirectToPage("./Lockout");
            }
            else
            {
                // Le code d'authentification à deux facteurs est incorrect, enregistre un message de journalisation
                _logger.LogWarning("Code d'authentification incorrect pour l'utilisateur avec l'ID '{UserId}'.", user.Id);

                // Ajoute une erreur de modèle pour afficher un message d'erreur à l'utilisateur
                ModelState.AddModelError(string.Empty, "Code d'authentification incorrect.");

                // Recharge la page actuelle
                return Page();
            }
        }

    }
}



