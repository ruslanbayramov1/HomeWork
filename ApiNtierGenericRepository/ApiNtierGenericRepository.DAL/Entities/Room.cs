namespace ApiNtierGenericRepository.DAL.Entities;

public class Room : AuditableEntity
{
    public string Name { get; set; } = null!;
    public int Capacity { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
}
