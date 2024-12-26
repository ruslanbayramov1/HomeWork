using ApiNtierGenericRepository.BL.DTOs.Lessons;

namespace ApiNtierGenericRepository.BL.Services.Interfaces;

public interface ILessonService
{
    Task<List<LessonGetDto>> GetAllAsync();
    Task<LessonGetDto> GetByIdAsync(int id);
    Task CreateAsync(LessonCreateDto dto);
    Task UpdateAsync(LessonUpdateDto dto);
    Task Delete(int id);
}
