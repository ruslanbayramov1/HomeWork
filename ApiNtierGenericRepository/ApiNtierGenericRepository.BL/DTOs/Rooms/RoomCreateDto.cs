namespace ApiNtierGenericRepository.BL.DTOs.Rooms;

public class RoomCreateDto
{
    public string Name { get; set; } = null!;
    public int Capacity { get; set; }
}
