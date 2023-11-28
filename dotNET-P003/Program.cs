using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciamentoEstoque
{
    class Program
    {
        // Definição da tupla para representar um produto
        public record Produto(int Codigo, string Nome, int QuantidadeEmEstoque, double PrecoUnitario);

        // Lista de produtos em estoque
        static List<Produto> estoque = new List<Produto>();

        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("========= Gerenciamento de Estoque =========");
                Console.WriteLine("|        1 - Cadastrar Produto             |");
                Console.WriteLine("|        2 - Consultar Produto por Código  |");
                Console.WriteLine("|        3 - Atualizar Estoque             |");
                Console.WriteLine("|        4 - Gerar Relatórios              |");
                Console.WriteLine("|        5 - Sair                          |");
                Console.WriteLine("|==========================================|");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            CadastrarProduto();
                            break;
                        case 2:
                            ConsultarProdutoPorCodigo();
                            break;
                        case 3:
                            AtualizarEstoque();
                            break;
                        case 4:
                            GerarRelatorios();
                            break;
                        case 5:
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

       static void CadastrarProduto()
{
    try
    {
        Console.WriteLine("======= Cadastro de Produto =======");
        Console.Write("Informe o código do produto: ");
        string? input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            if (int.TryParse(input, out int codigo))
            {
                Console.Write("Informe o nome do produto: ");
                string? nome = Console.ReadLine();

                if (!string.IsNullOrEmpty(nome)) // Verifica se o nome não é nulo ou vazio
                {
                    Console.Write("Informe a quantidade em estoque: ");
                    string? quantidadeStr = Console.ReadLine();

                    if (!string.IsNullOrEmpty(quantidadeStr) && int.TryParse(quantidadeStr, out int quantidade))
                    {
                        Console.Write("Informe o preço unitário: ");
                        string? precoStr = Console.ReadLine();

                        if (!string.IsNullOrEmpty(precoStr) && double.TryParse(precoStr, out double preco))
                        {
                            Produto novoProduto = new Produto(codigo, nome, quantidade, preco);
                            estoque.Add(novoProduto);

                            Console.WriteLine("Produto cadastrado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Preço inválido. Cadastro cancelado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Quantidade inválida. Cadastro cancelado.");
                    }
                }
                else
                {
                    Console.WriteLine("Nome inválido. Cadastro cancelado.");
                }
            }
            else
            {
                Console.WriteLine("Código inválido. Cadastro cancelado.");
            }
        }
        else
        {
            Console.WriteLine("Código não pode ser vazio. Cadastro cancelado.");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Erro ao cadastrar o produto. Verifique as entradas.");
    }
}



        static void ConsultarProdutoPorCodigo()
{
    Console.WriteLine("======= Consulta de Produto por Código =======");
    Console.Write("Informe o código do produto: ");

    string? inputCodigo = Console.ReadLine(); // Input do usuário, que pode ser nulo

    if (inputCodigo != null)
    {
        if (int.TryParse(inputCodigo, out int codigo)) // Tenta converter para int
        {
            Produto? produto = estoque.FirstOrDefault(p => p.Codigo == codigo);

            if (produto != null)
            {
                Console.WriteLine($"Produto encontrado: {produto.Nome} - Quantidade: {produto.QuantidadeEmEstoque} - Preço Unitário: {produto.PrecoUnitario:C}");
            }
            else
            {
                throw new ProdutoNaoEncontradoException("Produto não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Código inválido. Certifique-se de informar um número válido.");
        }
    }
    else
    {
        Console.WriteLine("Nenhuma entrada fornecida para o código do produto.");
    }
}


        static void AtualizarEstoque()
{
    try
    {
        Console.WriteLine("======= Atualização de Estoque =======");
        Console.Write("Informe o código do produto: ");

        string? inputCodigo = Console.ReadLine(); // Input do usuário, que pode ser nulo

        if (inputCodigo != null)
        {
            if (int.TryParse(inputCodigo, out int codigo)) // Tenta converter para int
            {
                Produto? produto = estoque.FirstOrDefault(p => p.Codigo == codigo);

                if (produto != null)
                {
                    Console.WriteLine($"Produto encontrado: {produto.Nome} - Quantidade: {produto.QuantidadeEmEstoque}");

                    Console.Write("Deseja adicionar (+) ou remover (-) quantidade do estoque? ");
                    string? operacao = Console.ReadLine(); // Input do usuário, que pode ser nulo

                    if (operacao != null)
                    {
                        Console.Write("Informe a quantidade: ");

                        string? inputQuantidade = Console.ReadLine(); // Input do usuário, que pode ser nulo

                        if (inputQuantidade != null)
                        {
                            if (int.TryParse(inputQuantidade, out int quantidade)) // Tenta converter para int
                            {
                                if (operacao == "+")
                                {
                                    produto = produto with { QuantidadeEmEstoque = produto.QuantidadeEmEstoque + quantidade };
                                    Console.WriteLine($"Estoque atualizado: {produto.QuantidadeEmEstoque}");
                                }
                                else if (operacao == "-")
                                {
                                    if (produto.QuantidadeEmEstoque >= quantidade)
                                    {
                                        produto = produto with { QuantidadeEmEstoque = produto.QuantidadeEmEstoque - quantidade };
                                        Console.WriteLine($"Estoque atualizado: {produto.QuantidadeEmEstoque}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Quantidade insuficiente em estoque para remover.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Operação inválida.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Quantidade inválida. Certifique-se de informar um número válido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma entrada fornecida para a quantidade.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma entrada fornecida para a operação.");
                    }
                }
                else
                {
                    throw new ProdutoNaoEncontradoException("Produto não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Código inválido. Certifique-se de informar um número válido.");
            }
        }
        else
        {
            Console.WriteLine("Nenhuma entrada fornecida para o código do produto.");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Erro ao atualizar o estoque. Verifique as entradas.");
    }
}


        static void GerarRelatorios()
        {
            Console.WriteLine("========================== Relatórios ================================");
            Console.WriteLine("| 1 - Lista de produtos com quantidade em estoque abaixo de um limite|");
            Console.WriteLine("| 2 - Lista de produtos com valor entre um mínimo e um máximo        |");
            Console.WriteLine("| 3 - Valor total do estoque e valor total de cada produto           |");
            Console.WriteLine("|====================================================================|");
            Console.Write("Escolha um relatório para gerar: ");
           
            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                switch (opcao)
                {
                    case 1:
                        ListaProdutosAbaixoDoLimite();
                        break;
                    case 2:
                        ListaProdutosEntreValores();
                        break;
                    case 3:
                        ValorTotalEstoque();
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }

        static void ListaProdutosAbaixoDoLimite()
{
    try
    {
        Console.Write("Informe o limite de quantidade: ");
        string? inputLimite = Console.ReadLine(); // Input do usuário, que pode ser nulo

        if (inputLimite != null)
        {
            if (int.TryParse(inputLimite, out int limite)) // Tenta converter para int
            {
                var produtosAbaixoLimite = estoque.Where(p => p.QuantidadeEmEstoque < limite);
                if (produtosAbaixoLimite.Any())
                {
                    Console.WriteLine("Produtos com quantidade abaixo do limite:");
                    foreach (var produto in produtosAbaixoLimite)
                    {
                        Console.WriteLine($"{produto.Nome} - Quantidade: {produto.QuantidadeEmEstoque}");
                    }
                }
                else
                {
                    Console.WriteLine("Não há produtos com quantidade abaixo do limite informado.");
                }
            }
            else
            {
                Console.WriteLine("Limite inválido. Certifique-se de informar um número válido.");
            }
        }
        else
        {
            Console.WriteLine("Nenhuma entrada fornecida para o limite de quantidade.");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Erro ao gerar relatório. Limite inválido.");
    }
}

        static void ListaProdutosEntreValores()
{
    try
    {
        Console.Write("Informe o valor mínimo: ");
        string? inputMinimo = Console.ReadLine(); // Input do usuário, que pode ser nulo

        Console.Write("Informe o valor máximo: ");
        string? inputMaximo = Console.ReadLine(); // Input do usuário, que pode ser nulo

        if (inputMinimo != null && inputMaximo != null)
        {
            if (double.TryParse(inputMinimo, out double minimo) && double.TryParse(inputMaximo, out double maximo)) // Tenta converter para double
            {
                var produtosEntreValores = estoque.Where(p => p.PrecoUnitario >= minimo && p.PrecoUnitario <= maximo);
                if (produtosEntreValores.Any())
                {
                    Console.WriteLine("Produtos com preço entre os valores informados:");
                    foreach (var produto in produtosEntreValores)
                    {
                        Console.WriteLine($"{produto.Nome} - Preço: {produto.PrecoUnitario:C}");
                    }
                }
                else
                {
                    Console.WriteLine("Não há produtos com preço entre os valores informados.");
                }
            }
            else
            {
                Console.WriteLine("Valores inválidos. Certifique-se de informar números válidos.");
            }
        }
        else
        {
            Console.WriteLine("Nenhuma entrada fornecida para os valores mínimo e máximo.");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Erro ao gerar relatório. Valores inválidos.");
    }
}


        static void ValorTotalEstoque()
        {
            double valorTotalEstoque = estoque.Sum(p => p.QuantidadeEmEstoque * p.PrecoUnitario);

            Console.WriteLine($"Valor total do estoque: {valorTotalEstoque:C}");

            Console.WriteLine("Valor total de cada produto:");
            foreach (var produto in estoque)
            {
                double valorProduto = produto.QuantidadeEmEstoque * produto.PrecoUnitario;
                Console.WriteLine($"{produto.Nome} - Valor Total: {valorProduto:C}");
            }
        }
    }

    // Exceção personalizada para Produto não encontrado
    public class ProdutoNaoEncontradoException : Exception
    {
        public ProdutoNaoEncontradoException(string message) : base(message) { }
    }
}
