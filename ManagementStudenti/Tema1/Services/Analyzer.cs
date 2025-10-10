namespace Tema1
{
    public static class Analyzer
    {
        public static void Analyze(object obj)
        {
            switch (obj)
            {
                case Task t:
                    Console.WriteLine($"Task: '{t.Title}', Completed: {t.IsCompleted}, Due: {t.DueDate:d}");
                    break;
                case Project p:
                    Console.WriteLine($"Project: '{p.Name}', Tasks count: {p.Tasks?.Count ?? 0}");
                    break;
                default:
                    Console.WriteLine("Unknown type");
                    break;
            }
        }
    }
}