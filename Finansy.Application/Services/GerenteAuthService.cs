using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Finansy.Application.Contracts;
using Finansy.Application.Dtos.V1.Auth;
using Finansy.Application.Notifications;
using Finansy.Core.Enums;
using Finansy.Core.Extensions;
using Finansy.Core.Settings;
using Finansy.Domain.Contracts.Repositories;
using Finansy.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Security.Jwt.Core.Interfaces;

namespace Finansy.Application.Services;

public class GerenteAuthService : BaseService, IGerenteAuthService
{
    private readonly IPasswordHasher<Gerente> _passwordHasher;
    private readonly JwtSettings _jwtSettings;
    private readonly IJwtService _jwtService;
    private readonly IGerenteRepository _gerenteRepository;
    public GerenteAuthService(IMapper mapper, INotificator notificator, IPasswordHasher<Gerente> passwordHasher, IOptions<JwtSettings> jwtSettings, IJwtService jwtService, IGerenteRepository gerenteRepository) : base(mapper, notificator)
    {
        _passwordHasher = passwordHasher;
        _jwtSettings = jwtSettings.Value;
        _jwtService = jwtService;
        _gerenteRepository = gerenteRepository;
    }

    public async Task<TokenDto?> Login(LoginDto dto)
    {
        var gerente = await _gerenteRepository.ObterPorEmail(dto.Email);
        if (gerente == null)
        {
            Notificator.HandleNotFoundResourse();
            return null;
        }

        if (_passwordHasher.VerifyHashedPassword(gerente, gerente.Senha, dto.Senha) !=
            PasswordVerificationResult.Failed)
            return new TokenDto
            {
                Token = await CreateToken(gerente)
            };
        
        return null;
    }
    
    private async Task<string> CreateToken(Gerente gerente)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, gerente.Id.ToString()));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, gerente.Nome));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, gerente.Email));
        claimsIdentity.AddClaim(new Claim("TipoUsuario", ETipoUsuario.Comum.ToDescriptionString()));

        var key = await _jwtService.GetCurrentSigningCredentials();
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = _jwtSettings.Emissor,
            Audience = _jwtSettings.GestaoValidoEm,
            Subject = claimsIdentity,
            Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiracaoHoras),
            SigningCredentials = key
        });

        return tokenHandler.WriteToken(token);
    }
}