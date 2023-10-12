namespace Finansy.Application.Dtos.V1.Unidade;

public class AtualizarUnidadeDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Nire { get; set; }
    public string Telefone { get; set; } = null!;
    public string Cep { get; set; } = null!;
    public string Logradouro { get; set; } = null!;
    public long Numero { get; set; }
    public string? Complemento { get; set; }
    public string Bairro { get; set; } = null!;
    public string Cidade { get; set; } = null!;
    public string Estado { get; set; } = null!;
    public string Cpf { get; set; } = null!;
}