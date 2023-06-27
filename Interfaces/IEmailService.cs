using Portfolio.Models;

namespace Portfolio.Interfaces
{
    public interface IEmailService
    {
        Task Send(ContactDTO contact);
    }
}
