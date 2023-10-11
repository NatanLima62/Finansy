using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Finansy.Application.Contracts;
using Finansy.Application.Dtos.v1.Administrador.AdministradorAuthDto;
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

public class AdministradorAuthService : BaseService, IAdministradorAuthService
{
    private readonly JwtSettings _jwtSettings;
    private readonly IJwtService _jwtService;
    private readonly IAdministradorRepository _administradorRepository;
    private readonly IPasswordHasher<Administrador> _administradorPasswordHasher;

    public AdministradorAuthService(IMapper mapper, INotificator notificator,
        IPasswordHasher<Administrador> administradorPasswordHasher, IAdministradorRepository administradorRepository,
        IOptions<JwtSettings> jwtSettings, IJwtService jwtService) : base(mapper, notificator)
    {
        _administradorPasswordHasher = administradorPasswordHasher;
        _administradorRepository = administradorRepository;
        _jwtSettings = jwtSettings.Value;
        _jwtService = jwtService;
    }

    public async Task<TokenDto?> Login(AdministradorLoginDto dto)
    {
        var administrador = await _administradorRepository.ObterPorEmail(dto.Email);
        if (administrador == null)
        {
            Notificator.HandleNotFoundResourse();
            return null;
        }

        if (_administradorPasswordHasher.VerifyHashedPassword(administrador, administrador.Senha, dto.Senha) !=
            PasswordVerificationResult.Failed)
            return new TokenDto
            {
                Token = await CreateToken(administrador)
            };
        
        return null;
    }

    private async Task<string> CreateToken(Administrador administrador)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, administrador.Id.ToString()));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, administrador.Nome));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, administrador.Email));
        claimsIdentity.AddClaim(new Claim("TipoUsuario", ETipoUsuario.Administrador.ToDescriptionString()));

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