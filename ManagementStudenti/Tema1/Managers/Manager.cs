// csharp
namespace Tema1.Managers
{
    public class Manager
    {
        public string Name { get; init; }
        public string Team { get; init; }
        public string Email { get; init; }

        public Manager(string name, string team, string email)
        {
            Name = name;
            Team = team;
            Email = email;
        }

        public override string ToString()
        {
            return ($"Manager(Name: {Name}, Team: {Team}, Email: {Email})");
        }
    }
}