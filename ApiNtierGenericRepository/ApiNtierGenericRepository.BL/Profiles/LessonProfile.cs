using ApiNtierGenericRepository.BL.DTOs.Lessons;
using ApiNtierGenericRepository.DAL.Entities;
using AutoMapper;

namespace ApiNtierGenericRepository.BL.Profiles;

public class LessonProfile : Profile
{
    public LessonProfile()
    {
        CreateMap<Lesson, LessonGetDto>();
        CreateMap<LessonCreateDto, Lesson>();
        CreateMap<LessonUpdateDto, Lesson>();
    }
}
