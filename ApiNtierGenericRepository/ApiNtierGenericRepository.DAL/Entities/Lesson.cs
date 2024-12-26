namespace ApiNtierGenericRepository.DAL.Entities;

public class Lesson : AuditableEntity
{
    public string Name { get; set; }
    public DateTime ScheduleAt { get; set; }
    public DateTime ScheduleEnd { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
}
