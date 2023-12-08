namespace SubsAPI.Models;

public class IMC {
    public int? Id { get; set; }
    public double Altura { get; set; }
    public double Peso { get; set; }
    public double? IMCValor { get; set; }
    public string? Classificacao { get; set; }
    public int? GrauObesidade { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now;
    public int AlunoId { get; set; }
    public Aluno? Aluno { get; set; }
}