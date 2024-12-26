namespace ApiNtierGenericRepository.BL.DTOs.Groups;

public class GroupGetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int StudentCount { get; set; }
}
