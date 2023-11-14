using System;

#region 

/*
1. Escreva um programa em C# que imprime todos os números que são
divisíveis por 3 ou por 4 entre 0 e 30;
*/
class Program
{
    static void Main()
    {
        Console.WriteLine("Números divisíveis por 3 ou por 4 entre 0 e 30:");

        for (int i = 0; i <= 30; i++)
        {
            if (i % 3 == 0 || i % 4 == 0)
            {
                Console.WriteLine(i);
            }
        }

        Console.ReadLine(); // Aguarda a entrada do usuário antes de fechar a janela
    }
}

#endregion

#region 


#endregion