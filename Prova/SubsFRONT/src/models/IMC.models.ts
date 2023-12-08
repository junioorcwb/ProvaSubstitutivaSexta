import { Aluno } from './Aluno.Models';
export class IMC {

    id! : number
    altura! : number
    peso! : number
    imcValor! : number
    classificacao! : string
    grauObesidade! : number
    alunoId! : number
    aluno! : Aluno

    // public int? Id { get; set; }
    // public double Altura { get; set; }
    // public double Peso { get; set; }
    // public double? IMCValor { get; set; }
    // public string? Classificacao { get; set; }
    // public int? GrauObesidade { get; set; }
    // public DateTime CriadoEm { get; set; } = DateTime.Now;
    // public int AlunoId { get; set; }
    // public Aluno? Aluno { get; set; }
}