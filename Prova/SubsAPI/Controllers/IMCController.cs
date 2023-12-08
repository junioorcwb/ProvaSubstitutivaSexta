using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubsAPI.Data;
using SubsAPI.DTOs;
using SubsAPI.Models;

namespace SubsAPI.Controllers;

[ApiController]
[Route("IMC")]
public class IMCController : ControllerBase {

    private readonly AppDatabase _banco;
    public IMCController(AppDatabase banco)
    {
        _banco = banco;
    }
    
    [HttpPost("cadastrar")]
    public IActionResult CadastrarIMC([FromBody] IMCDTO imcDTO){

        Aluno alunoImc = _banco.Alunos.FirstOrDefault(a => a.Id == imcDTO.AlunoId);

        var imcValor = imcDTO.Peso / (imcDTO.Altura * 2);
        
        IMC imcCriado = new(){
            Altura = imcDTO.Altura,
            Peso = imcDTO.Peso,
            Aluno = alunoImc,
            IMCValor = imcValor
        };

        if(imcValor < 18.5){
            imcCriado.Classificacao = "Magreza";
            imcCriado.GrauObesidade = 0;
        } else if(imcValor < 25){
            imcCriado.Classificacao = "Normal";
            imcCriado.GrauObesidade = 0;
        } else if(imcValor < 30){
            imcCriado.Classificacao = "Sobrepeso";
            imcCriado.GrauObesidade = 1;
        } else if(imcValor < 40){
            imcCriado.Classificacao = "Obesidade";
            imcCriado.GrauObesidade = 2;
        } else {
            imcCriado.Classificacao = "Obesidad Grave";
            imcCriado.GrauObesidade = 3;
        }

        _banco.IMCs.Add(imcCriado);
        _banco.SaveChanges();

        return Created("", imcCriado);
    }

    [HttpGet("listar")]
    public IActionResult ListarIMCs(){

        List<IMC> IMCs = _banco.IMCs.ToList(); 

        return Ok(IMCs);
    }

    [HttpGet("buscar/{id}")]
    public IActionResult BuscarIMC([FromRoute] int id){
        
        IMC imc = _banco.IMCs.Include(a => a.Aluno).FirstOrDefault(i => i.Id == id);
        
        return Ok(imc);
    }

    [HttpPut("alterar/{id}")]
    public IActionResult AlterarIMC([FromRoute] int id, [FromBody] IMC imc){
        
        IMC imcDB = _banco.IMCs.Include(a => a.Aluno).FirstOrDefault(i => i.Id == id);

        imcDB.Altura = imc.Altura;
        imcDB.Peso = imc.Peso;

        var imcValor = imcDB.Peso / (imcDB.Altura * 2);

        if(imcValor < 18.5){
            imcDB.IMCValor = imcValor;
            imcDB.Classificacao = "Magreza";
            imcDB.GrauObesidade = 0;
        } else if(imcValor < 25){
            imcDB.IMCValor = imcValor;
            imcDB.Classificacao = "Normal";
            imcDB.GrauObesidade = 0;
        } else if(imcValor < 30){
            imcDB.IMCValor = imcValor;
            imcDB.Classificacao = "Sobrepeso";
            imcDB.GrauObesidade = 1;
        } else if(imcValor < 40){
            imcDB.IMCValor = imcValor;
            imcDB.Classificacao = "Obesidade";
            imcDB.GrauObesidade = 2;
        } else {
            imcDB.IMCValor = imcValor;
            imcDB.Classificacao = "Obesidad Grave";
            imcDB.GrauObesidade = 3;
        }

        _banco.SaveChanges();
        
        return Ok(imcDB);
    }
}