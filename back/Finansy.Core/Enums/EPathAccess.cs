using System.ComponentModel;

namespace Finansy.Core.Enums;

public enum EPathAccess
{
    [Description("assets/public")]
    Public,
    [Description("assets/private")]
    Private
}