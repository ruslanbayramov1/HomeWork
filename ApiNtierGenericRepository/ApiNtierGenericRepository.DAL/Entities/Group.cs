namespace ApiNtierGenericRepository.DAL.Entities;

public class Group : AuditableEntity
{
    public string Name { get; set; } = null!;
    public int StudentCount { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
}
