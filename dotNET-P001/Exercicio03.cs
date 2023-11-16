/*
3. Conversão de Tipos de Dados:
Problema: Suponha que você tenha uma variável do tipo double e deseja convertê-la
em um tipo int. Como você faria essa conversão e o que aconteceria se a parte
fracionária da variável double não pudesse ser convertida em um int? Resolva o
problema através de um exemplo em C#.
*/

#region

// Utilizando Convert.TOInt32() para efetuar a conversão

double numDouble = 15.78;
int numInteiro = Convert.ToInt32(numeroDouble); // Utilizando Convert.ToInt32()

Console.WriteLine($"Número double: {numDouble}");
Console.WriteLine($"Número inteiro após conversão: {numInteiro}");

#endregion

/****************************************************************************************/

#region

// Utilizando cast para efetuar a conversão

double numeroDouble = 20.56;
int numeroInteiro = (int)numeroDouble; // Usando cast direto

Console.WriteLine($"Número double: {numeroDouble}");
Console.WriteLine($"Número inteiro após conversão: {numeroInteiro}");

#endregion