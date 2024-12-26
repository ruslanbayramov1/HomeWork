using ApiNtierGenericRepository.BL.Services.Implements;
using ApiNtierGenericRepository.BL.Services.Interfaces;
using ApiNtierGenericRepository.DAL.Entities;
using ApiNtierGenericRepository.DAL.Repositories.Implements;
using ApiNtierGenericRepository.DAL.Repositories.Interfaces;

namespace ApiNtierGenericRepository.API;

public static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection service)
    {
        service.AddAutoMapper(typeof(Program).Assembly);

        service.AddScoped<ILessonService, LessonService>();
        service.AddScoped<IRepository<Lesson>, Repository<Lesson>>();
        return service;
    }
}
