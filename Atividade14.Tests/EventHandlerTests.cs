using NSubstitute;

namespace Atividade14.Tests;
public class EventHandlerTests
{
    [Fact]
    public void HandleEvent_WithMessage_SendsEmail()
    {
        // Arrange
        var emailService = Substitute.For<IEmailService>();
        var eventHandler = new EventHandler(emailService);
        string eventMessage = "An event has occurred";

        // Act
        eventHandler.HandleEvent(eventMessage);

        // Assert
        emailService.Received(1).SendEmail(
            "test@example.com",
            "Event Occurred",
            eventMessage);
    }
}
