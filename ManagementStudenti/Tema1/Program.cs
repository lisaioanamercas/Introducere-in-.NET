// csharp
using Tema1;

Console.WriteLine("Simple Task and Project Manager Demo ");

var tasks = TaskService.CreateSampleTasks();
var projects = TaskService.CreateSampleProjects(tasks);

TaskService.DisplayAll(tasks);

while (true)
{
    Console.Write("\nEnter a task title to mark as completed (or empty to exit): ");
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input)) break;

    if (TaskService.MarkCompletedByTitle(tasks, input))
        Console.WriteLine($"Marked '{input}' as completed.");
    else
        Console.WriteLine($"Task '{input}' not found.");

    TaskService.DisplayAll(tasks);
}

Console.WriteLine();
TaskService.PrintOverdue(tasks);

Console.WriteLine("\nPattern analysis examples:");
Analyzer.Analyze(tasks[0]);
Analyzer.Analyze(projects[0]);
Analyzer.Analyze("some string");