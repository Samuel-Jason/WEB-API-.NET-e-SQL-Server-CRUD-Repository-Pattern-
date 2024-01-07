using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using WebApi.Enums;

namespace WebApi.Model
{
    public class Funcionario
    {
        public Funcionario()
        {
        }

        public Funcionario(string nome, string idade)
        {
            Nome = nome;
            Idade = idade;
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DepartamentoEnum Departamento { get; set; }
        public bool Ativo { get; set; }
        public TurnoEnum Turno { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
        public string Idade { get; set; }
        public string? Email { get; set; }

        public async Task<List<Funcionario>> ObterFuncionarios()
        {
            Random random = new Random();

            return new List<Funcionario>
            {
                new Funcionario("Funcionario1", random.Next(18, 60).ToString()),
                new Funcionario("Funcionario2", random.Next(18, 60).ToString()),
                new Funcionario("Funcionario3", random.Next(18, 60).ToString()),
                new Funcionario("Funcionario4", random.Next(18, 60).ToString()),
                new Funcionario("Funcionario5", random.Next(18, 60).ToString())
            };
        }
    }
}