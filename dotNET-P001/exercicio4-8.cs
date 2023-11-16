#region 
/*
4. Operadores Aritméticos:
Problema: Dada a variável int x = 10 e a variável int y = 3, escreva código para calcular
e exibir o resultado da adição, subtração, multiplicação e divisão de x por y
*/
using System;

        int x = 20;
        int y = 4;

        int adicao = x + y;
        int subtracao = x - y;
        int multiplicacao = x * y;
        int divisao = x / y; 

        Console.WriteLine($"Adição: {adicao}");
        Console.WriteLine($"Subtração: {subtracao}");
        Console.WriteLine($"Multiplicação: {multiplicacao}");
        Console.WriteLine($"Divisão: {divisao}");
      
#endregion

#region 
/*
5. Operadores de Comparação:
Problema: Considere as variáveis int a = 5 e int b = 8. Escreva código para determinar
se a é maior que b e exiba o resultado.*/

        int a = 5;
        int b = 8;

        if (a > b)
        {
            Console.WriteLine("a é maior que b");
        }
        else
        {
            Console.WriteLine("a não é maior que b");
        }

#endregion

#region
/*
6. Operadores de Igualdade:
Problema: Você tem duas strings, string str1 = "Hello" e string str2 = "World". Escreva
código para verificar se as duas strings são iguais e exibir o resultado.
se a é maior que b e exiba o resultado.*/


        string str1 = "Hello";
        string str2 = "World";

        if (str1 == str2)
        {
            Console.WriteLine("As strings são iguais.");
        }
        else
        {
            Console.WriteLine("As strings são diferentes.");
        }

#endregion

#region 
/*
7. Operadores Lógicos:
Problema: Suponha que você tenha duas variáveis booleanas, bool condicao1 = true
e bool condicao2 = false. Escreva código para verificar se ambas as condições são
verdadeiras e exiba o resultado.
*/

        bool condicao1 = true;
        bool condicao2 = false;

        if (condicao1 && condicao2)
        {
            Console.WriteLine("Ambas as condições são verdadeiras.");
        }
        else
        {
            Console.WriteLine("Pelo menos uma das condições é falsa.");
        }

#endregion

#region 

/*
8. Desafio de Mistura de Operadores:
Problema: Dadas as variáveis int num1 = 7, int num2 = 3, e int num3 = 10, escreva
código para verificar se num1 é maior do que num2 e se num3 é igual a num1 + num2.*/

        int num1 = 7;
        int num2 = 3;
        int num3 = 10;

        if (num1 > num2 && num3 == num1 + num2)
        {
            Console.WriteLine("num1 é maior que num2 e num3 é igual a num1 + num2.");
        }
        else
        {
            Console.WriteLine("As condições não são ambas verdadeiras.");
        }
#endregion