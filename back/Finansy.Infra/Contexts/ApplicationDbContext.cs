using Finansy.Core.Authorization.AuthenticatedUser;
using Microsoft.EntityFrameworkCore;

namespace Finansy.Infra.Contexts;

public sealed class ApplicationDbContext : BaseApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IAuthenticatedUser authenticatedUser) : base(options, authenticatedUser)
    {
    }
}