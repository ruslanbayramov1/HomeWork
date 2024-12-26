namespace ApiNtierGenericRepository.BL.DTOs.Rooms;

public class RoomGetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Capacity { get; set; }
}
