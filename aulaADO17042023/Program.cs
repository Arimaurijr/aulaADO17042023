using System.ComponentModel;
using aulaADO17042023.Controllers;
using aulaADO17042023.Model;
using aulaADO17042023.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Proj MVC - ADO.NET");
        Console.WriteLine("Teste Inclusão de dados");

        Aviao aviao = new()
        {
            Description = "Para testes",
            Id = 1,
            Name = "TOP TURBO",
            NumberOfPassagers = 20,
            Engine = new()
            {
                Description = "Muito veloz"
            }
        };

        /*
        for (int i = 0; i <= 1; i++)
        {
            if (new AirplaneController().Insert(aviao))
            {
                Console.WriteLine("Sucesso ! registro inserido !");
            }
            else
            {
                Console.WriteLine("Erro ao inserir registro");
            }
        }
        */

        new AirplaneController().FindAll().ForEach(Console.WriteLine);
    }
}