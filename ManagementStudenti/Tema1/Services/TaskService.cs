// csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tema1
{
    public static class TaskService
    {
        public static List<Task> CreateSampleTasks() => new()
        {
            new Task("Feed the cat", false, DateTime.Now.AddDays(-1)),
            new Task("Finish report", false, DateTime.Now.AddDays(2)),
            new Task("JWT Implementation", true, DateTime.Now.AddDays(-2)),
            new Task("Curs .NET", false, DateTime.Now.AddDays(5)),
        };
        public static List<Project> CreateSampleProjects(List<Task> tasks) => new()
        {
            new Project("Domestic", new List<Task> { tasks[0], tasks[1] }),
            new Project("Work", new List<Task> { tasks[2], tasks[3] }),
        };

        public static void DisplayAll(List<Task> tasks)
        {
            Console.WriteLine("\nCurrent Tasks:");
            foreach (var t in tasks)
                Console.WriteLine($"- {t.Title} | Completed: {t.IsCompleted} | Due: {t.DueDate:g}");
        }

        public static bool MarkCompletedByTitle(List<Task> tasks, string title)
        {
            var idx = tasks.FindIndex(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (idx < 0)
            {
                return false;
            }
            var updated = tasks[idx] with { IsCompleted = true };
            tasks[idx] = updated; // replace cloned record
            return true;
        }

        public static IEnumerable<Task> OverdueNotCompleted(List<Task> tasks)
            => tasks.Where(t => !t.IsCompleted && t.DueDate < DateTime.Now)
                .OrderBy(t => t.DueDate);

        public static void PrintOverdue(List<Task> tasks)
        {
            Console.WriteLine("\nOverdue and not completed tasks:");
            foreach (var t in OverdueNotCompleted(tasks))
                Console.WriteLine($"- {t.Title} (due {t.DueDate:d})");
        }
    }
}