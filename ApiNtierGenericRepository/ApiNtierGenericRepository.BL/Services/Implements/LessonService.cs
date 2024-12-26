using ApiNtierGenericRepository.BL.DTOs.Lessons;
using ApiNtierGenericRepository.BL.Services.Interfaces;
using ApiNtierGenericRepository.DAL.DataAccess;
using ApiNtierGenericRepository.DAL.Entities;
using ApiNtierGenericRepository.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiNtierGenericRepository.BL.Services.Implements;

public class LessonService : ILessonService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IRepository<Lesson> _repository;
    public LessonService(AppDbContext context, IMapper mapper, IRepository<Lesson> repository)
    {
        _context = context;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task CreateAsync(LessonCreateDto dto)
    {
        var entity = _mapper.Map<Lesson>(dto);
        await _repository.CreateAsync(entity);
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<LessonGetDto>> GetAllAsync()
    {
        var query = await _repository.GetAllAsync();
        var entities = await query.ToListAsync();
        var data = _mapper.Map<List<LessonGetDto>>(entities);

        return data;
    }

    public Task<LessonGetDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(LessonUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
