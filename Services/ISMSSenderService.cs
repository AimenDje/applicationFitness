namespace SuiviFitness.Services;
 public interface ISMSSenderService
{
    Task SendSmsAsync(string number, string message);
}
