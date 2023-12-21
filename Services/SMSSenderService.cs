using Microsoft.Extensions.Options;
using SuiviFitness.Settings;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SuiviFitness.Services
{
    /*
 * La classe SMSSenderService qui implémente l'interface ISMSSenderService.
 * Elle est utilisée pour envoyer des SMS en utilisant Twilio.
 * Le constructeur de la classe prend en charge la récupération
 * des paramètres de configuration Twilio depuis les options fournies.
 * La méthode SendSmsAsync est utilisée pour envoyer un SMS de manière
 * asynchrone en utilisant les paramètres de configuration Twilio
 * et le client Twilio.
 */
    public class SMSSenderService : ISMSSenderService
    {
        private readonly TwilioSettings _twilioSettings; // Paramètres de configuration Twilio
                                                         // Constructeur de la classe
        public SMSSenderService(IOptions<TwilioSettings> twilioSettings)
        {
            _twilioSettings = twilioSettings.Value; // Récupère les paramètres de  configuration Twilio depuis les options
                                                    // Le constructeur prend en argument des options de configuration Twilio.
        }
        // Méthode pour envoyer un SMS de manière asynchrone
        public async Task SendSmsAsync(string number, string message)
        {
            // Initialise le client Twilio en utilisant les informations d'identification de TwilioSettings
            TwilioClient.Init(_twilioSettings.AccountSId, _twilioSettings.AuthToken);
            // Crée un message SMS en utilisant Twilio et envoie le message
            await MessageResource.CreateAsync(
            to: number, // Numéro de téléphone du destinataire
            from: _twilioSettings.FromPhoneNumber, // Numéro de téléphone émetteur configuré dans TwilioSettings

            body: message // Corps du message SMS
            );
        }
    }
}
