using Finansy.Application.Notifications;
using Finansy.Core.Authorization;
using Finansy.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Finansy.Api.Controllers.V1.Administracao;

[Authorize]
[ClaimsAuthorize("TipoUsuario", ETipoUsuario.Administrador)]
public abstract class MainController : BaseController
{
    protected MainController(INotificator notificator) : base(notificator)
    {
    }
}