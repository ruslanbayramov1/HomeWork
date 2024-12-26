namespace ApiNtierGenericRepository.BL.DTOs.Lessons;

public class LessonGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime ScheduleAt { get; set; }
    public DateTime ScheduleEnd { get; set; }
    public int GroupId { get; set; }
    public int RoomId { get; set; }
}
