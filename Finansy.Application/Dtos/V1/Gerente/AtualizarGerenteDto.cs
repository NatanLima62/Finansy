namespace Finansy.Application.Dtos.V1.Gerente;

public class AtualizarGerenteDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public string? Telefone { get; set; }
    public string Cpf { get; set; } = null!;
    public string? Cnpj { get; set; }
}