namespace Finansy.Application.Dtos.v1.Administrador;

public class AtualizarAdministradorDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Telefone { get; set; }
    public string Cpf { get; set; } = null!;
}