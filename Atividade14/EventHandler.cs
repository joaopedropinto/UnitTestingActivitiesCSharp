namespace Atividade14
{
    public class EventHandler
    {
        private readonly IEmailService _emailService;

        public EventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void HandleEvent(string eventMessage)
        {
            _emailService.SendEmail("test@example.com", "Event Occurred", eventMessage);
        }
    }
}
