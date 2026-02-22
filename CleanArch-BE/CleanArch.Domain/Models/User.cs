namespace CleanArch.Domain.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordHashed { get; set; }
    public required string Email { get; set; }
    
    //Examples of connections
    // public Project ProjectInUse { get; set; }
    // public int ProjectInUseId { get; set; }
    
    //public List<Task> Tasks { get; set; } = new(); <--Task has - public int UserId { get; set; }  public User User
    
    //Followed examples included in Infrastructure/Persistence/DataContext
}