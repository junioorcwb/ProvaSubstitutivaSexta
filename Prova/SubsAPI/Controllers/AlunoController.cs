using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubsAPI.Data;
using SubsAPI.DTOs;
using SubsAPI.Models;

namespace SubsAPI.Controllers;

[ApiController]
[Route("alunos")]
public class AlunoController : ControllerBase {

    private readonly AppDatabase _banco;
    public AlunoController(AppDatabase banco)
    {
        _banco = banco;
    }

    [HttpPost("cadastrar")]
    public IActionResult CadastrarAluno([FromBody] AlunoDTO alunoDTO){
        
        Aluno alunoNovo = new(){
            Nome = alunoDTO.Nome,
            DataNascimento = alunoDTO.DataNascimento
        };

        _banco.Alunos.Add(alunoNovo);
        _banco.SaveChanges();

        return Created("", alunoNovo);
    }
}