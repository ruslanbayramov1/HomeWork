namespace ApiNtierGenericRepository.BL.DTOs.Groups;

public class GroupCreateDto
{
    public string Name { get; set; } = null!;
    public int StudentCount { get; set; }
}
