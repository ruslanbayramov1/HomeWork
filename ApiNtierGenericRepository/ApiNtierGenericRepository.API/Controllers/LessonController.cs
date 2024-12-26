using ApiNtierGenericRepository.BL.DTOs.Lessons;
using ApiNtierGenericRepository.BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNtierGenericRepository.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class LessonController : ControllerBase
{
    private readonly ILessonService _service;
    public LessonController(ILessonService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _service.GetAllAsync();
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Post(LessonCreateDto dto)
    { 
        await _service.CreateAsync(dto);
        return Created();
    }
}
