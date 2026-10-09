using MultyFormMessage.Models;

namespace MultyFormMessage.Services
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}