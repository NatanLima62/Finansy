using FluentValidation.Results;

namespace Finansy.Application.Notifications;

public interface INotificator
{
    bool HasNotification { get; }
    bool IsNotFoundResourse { get; }
    public void Handle(string message);
    public void Handle(List<ValidationFailure> failures);
    public void HandleNotFoundResourse();
    public IEnumerable<string> GetNotifications();
}