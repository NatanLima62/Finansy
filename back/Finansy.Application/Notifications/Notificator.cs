using FluentValidation.Results;

namespace Finansy.Application.Notifications;

public class Notificator : INotificator
{
    private readonly List<string> _erros;
    private bool _isNotFoundResource;

    public Notificator()
    {
        _erros = new List<string>();
    }

    public bool HasNotification => _erros.Any();
    public bool IsNotFoundResource => _isNotFoundResource;

    public void Handle(string message)
    {
        if (_isNotFoundResource)
            throw new InvalidOperationException("Não é possível chamar um handle quando for NotFoundResource");
        _erros.Add(message);
    }

    public void Handle(List<ValidationFailure> failures)
    {
        failures.ForEach(c => Handle(c.ErrorMessage));
    }

    public void HandleNotFoundResourse()
    {
        _isNotFoundResource = true;
    }

    public IEnumerable<string> GetNotifications() => _erros;
}