using Finansy.Application.Notifications;
using Finansy.Core.Authorization;
using Finansy.Core.Enums;

namespace Finansy.Api.Controllers.V1;

[ClaimsAuthorize("TipoUsuario", ETipoUsuario.Comum)]
public abstract class MainController : BaseController
{
    protected MainController(INotificator notificator) : base(notificator)
    {
    }
}