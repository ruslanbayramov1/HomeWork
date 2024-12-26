using ApiNtierGenericRepository.DAL.Entities;
using System.Linq.Expressions;

namespace ApiNtierGenericRepository.DAL.Repositories.Interfaces;

public interface IRepository<T> where T : BaseEntity, new()
{
    Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? exp = null, Expression<Func<T, object[]>>? includes = null);
    Task CreateAsync(T entity);
}
