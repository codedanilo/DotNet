using System;
using System.Collections.Generic;
using System.Linq;

public class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
}

public class Medico : Pessoa
{
    public string CRM { get; set; }
}

public class Paciente : Pessoa
{
    public string? Sexo { get; set; }
    public string? Sintomas { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Medico> medicos = new List<Medico>();
        List<Paciente> pacientes = new List<Paciente>();

        try
        {
            medicos.Add(new Medico { Nome = "Dr. João", DataNascimento = new DateTime(1980, 5, 15), CPF = "12345678900", CRM = "ABC123" });
            medicos.Add(new Medico { Nome = "Dra. Maria", DataNascimento = new DateTime(1975, 9, 25), CPF = "98765432100", CRM = "XYZ789" });

            pacientes.Add(new Paciente { Nome = "Carlos", DataNascimento = new DateTime(1995, 3, 10), CPF = "11122233344", Sexo = "Masculino", Sintomas = "Dor de cabeça" });
            pacientes.Add(new Paciente { Nome = "Ana", DataNascimento = new DateTime(1988, 7, 5), CPF = "55566677788", Sexo = "Feminino", Sintomas = "Febre" });
            pacientes.Add(new Paciente { Nome = "Mariana", DataNascimento = new DateTime(2000, 12, 20), CPF = "99988877766", Sexo = "Feminino", Sintomas = "Tosse" });

            var medicosPorIdade = medicos.Where(m => (DateTime.Now.Year - m.DataNascimento.Year) >= 35 && (DateTime.Now.Year - m.DataNascimento.Year) <= 50);
            Console.WriteLine("Médicos com idade entre 35 e 50 anos:");
            foreach (var medico in medicosPorIdade)
            {
                Console.WriteLine($"Nome: {medico.Nome}, Idade: {DateTime.Now.Year - medico.DataNascimento.Year}");
            }
            Console.WriteLine();

            var pacientesPorIdade = pacientes.Where(p => (DateTime.Now.Year - p.DataNascimento.Year) >= 20 && (DateTime.Now.Year - p.DataNascimento.Year) <= 30);
            Console.WriteLine("Pacientes com idade entre 20 e 30 anos:");
            foreach (var paciente in pacientesPorIdade)
            {
                Console.WriteLine($"Nome: {paciente.Nome}, Idade: {DateTime.Now.Year - paciente.DataNascimento.Year}");
            }
            Console.WriteLine();

            string sexoInformado = "Masculino";
            var pacientesPorSexo = pacientes.Where(p => p.Sexo != null && p.Sexo.Equals(sexoInformado, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"Pacientes do sexo {sexoInformado}:");
            foreach (var paciente in pacientesPorSexo)
            {
            Console.WriteLine($"Nome: {paciente.Nome}, Sexo: {paciente.Sexo ?? "Não especificado"}");
            }

            Console.WriteLine();

            var pacientesOrdenados = pacientes.OrderBy(p => p.Nome);
            Console.WriteLine("Pacientes em ordem alfabética:");
            foreach (var paciente in pacientesOrdenados)
            {
                Console.WriteLine($"Nome: {paciente.Nome}");
            }
            Console.WriteLine();

            string textoSintoma = "Dor";
            var pacientesPorSintoma = pacientes.Where(p => p.Sintomas != null && p.Sintomas.Contains(textoSintoma, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"Pacientes com sintomas contendo '{textoSintoma}':");
            foreach (var paciente in pacientesPorSintoma)
            {
    Console.WriteLine($"Nome: {paciente.Nome}, Sintomas: {paciente.Sintomas ?? "Sintomas não especificados"}");
            }

            Console.WriteLine();

            int mesInformado = 5;
            var aniversariantes = medicos.Where(m => m.DataNascimento.Month == mesInformado)
                                    .Cast<Pessoa>()
                                    .Union(pacientes.Where(p => p.DataNascimento.Month == mesInformado)
                                    .Cast<Pessoa>());
            Console.WriteLine($"Aniversariantes do mês {mesInformado}:");
            foreach (var pessoa in aniversariantes)
            {
                if (pessoa is Medico med)
                {
                    Console.WriteLine($"Médico: {med.Nome}, Dia do aniversário: {med.DataNascimento.Day}");
                }
                else if (pessoa is Paciente pac)
                {
                    Console.WriteLine($"Paciente: {pac.Nome}, Dia do aniversário: {pac.DataNascimento.Day}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}
