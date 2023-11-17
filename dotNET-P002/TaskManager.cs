using System;
using System.Collections.Generic;
using System.Linq;

class TaskManager
{
    class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
    }

    private List<Task> tasks = new List<Task>();

    public void AddTask()
    {
        Console.WriteLine("Digite o título da tarefa:");
        string title = Console.ReadLine();

        Console.WriteLine("Digite a descrição da tarefa:");
        string description = Console.ReadLine();

        Console.WriteLine("Digite a data de vencimento da tarefa (DD/MM/AAAA):");
        if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dueDate))
        {
            Console.WriteLine("Data inválida. Tarefa não adicionada.");
            return;
        }

        Task newTask = new Task
        {
            Title = title,
            Description = description,
            DueDate = dueDate,
            Completed = false
        };

        tasks.Add(newTask);
        Console.WriteLine("Tarefa adicionada com sucesso!");
    }

    public void ListAllTasks()
    {
        foreach (var task in tasks)
        {
            Console.WriteLine($"Título: {task.Title}");
            Console.WriteLine($"Descrição: {task.Description}");
            Console.WriteLine($"Data de vencimento: {task.DueDate.ToShortDateString()}");
            Console.WriteLine($"Estado: {(task.Completed ? "Concluída" : "Pendente")}");
            Console.WriteLine("----------------------");
        }
    }

public void MarkTaskAsCompleted()
    {
        Console.WriteLine("Digite o título da tarefa a ser marcada como concluída:");
        string title = Console.ReadLine();

        Task task = tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (task != null)
        {
            task.Completed = true;
            Console.WriteLine("Tarefa marcada como concluída!");
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada.");
        }
    }

    public void DeleteTask()
    {
        Console.WriteLine("Digite o título da tarefa a ser excluída:");
        string title = Console.ReadLine();

        Task task = tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (task != null)
        {
            tasks.Remove(task);
            Console.WriteLine("Tarefa excluída com sucesso!");
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada.");
        }
    }

    public void SearchTasks(string keyword)
    {
        var matchingTasks = tasks.Where(t => t.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) || t.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        if (matchingTasks.Any())
        {
            Console.WriteLine($"Tarefas encontradas com base na palavra-chave '{keyword}':");
            foreach (var task in matchingTasks)
            {
                Console.WriteLine($"Título: {task.Title}");
                Console.WriteLine($"Descrição: {task.Description}");
                Console.WriteLine($"Data de vencimento: {task.DueDate.ToShortDateString()}");
                Console.WriteLine($"Estado: {(task.Completed ? "Concluída" : "Pendente")}");
                Console.WriteLine("----------------------");
            }
        }
        else
        {
            Console.WriteLine($"Nenhuma tarefa encontrada com a palavra-chave '{keyword}'.");
        }
    }

    public void ShowStatistics()
    {
        int completedTasks = tasks.Count(t => t.Completed);
        int pendingTasks = tasks.Count(t => !t.Completed);

        Task oldestTask = tasks.OrderBy(t => t.DueDate).FirstOrDefault();
        Task newestTask = tasks.OrderByDescending(t => t.DueDate).FirstOrDefault();

        Console.WriteLine($"Número de tarefas concluídas: {completedTasks}");
        Console.WriteLine($"Número de tarefas pendentes: {pendingTasks}");

        if (oldestTask != null)
        {
            Console.WriteLine($"Tarefa mais antiga: {oldestTask.Title} - {oldestTask.DueDate.ToShortDateString()}");
        }

        if (newestTask != null)
        {
            Console.WriteLine($"Tarefa mais recente: {newestTask.Title} - {newestTask.DueDate.ToShortDateString()}");
        }
    }
}

class Program
{
    static void Main()
    {
        TaskManager taskManager = new TaskManager();

        while (true)
        {
            Console.WriteLine("\n=== Gerenciador de Tarefas ===\n");
            Console.WriteLine("1. Adicionar Tarefa");
            Console.WriteLine("2. Listar Todas as Tarefas");
            Console.WriteLine("3. Marcar Tarefa como Concluída");
            Console.WriteLine("4. Excluir Tarefa");
            Console.WriteLine("5. Pesquisar Tarefa");
            Console.WriteLine("6. Exibir Estatísticas");
            Console.WriteLine("7. Sair");
            Console.WriteLine("==============================");
            Console.WriteLine("Escolha uma opção:");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Escolha inválida.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    taskManager.AddTask();
                    break;
                case 2:
                    taskManager.ListAllTasks();
                    break;
                case 3:
                    taskManager.MarkTaskAsCompleted();
                    break;
                case 4:
                    taskManager.DeleteTask();
                    break;
                case 5:
                    Console.WriteLine("Digite a palavra-chave para pesquisa:");
                    string keyword = Console.ReadLine();
                    taskManager.SearchTasks(keyword);
                    break;
                case 6:
                    taskManager.ShowStatistics();
                    break;
                case 7:
                    Console.WriteLine("Saindo do programa...");
                    return;
                default:
                    Console.WriteLine("Escolha inválida.");
                    break;
            }
        }
    }
}
