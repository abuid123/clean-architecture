using CleanArchitecture.Application.Abstractions.Email;

namespace CleanArchitecture.Infraestructure.Email;

internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.Users.Email recipient, string subject, string body)
    {
        //Aca deberia ir la logica para enviar un email
        return Task.CompletedTask;
    }
}
