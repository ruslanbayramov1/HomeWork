using ApiNtierGenericRepository.DAL.DataAccess;
using ApiNtierGenericRepository.DAL.Entities;
using ApiNtierGenericRepository.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiNtierGenericRepository.DAL.Repositories.Implements;

public class Repository<T> : IRepository<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _table;
    public Repository(AppDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? exp = null, Expression<Func<T, object[]>>? includes = null)
    {
        var query = _table.AsQueryable();

        if (includes != null)
        { 
            query = query.Include(includes);
        }

        if (exp != null)
        {
            query = query.Where(exp);
        }

        return query;
    }

    public async Task CreateAsync(T entity)
    { 
        await _table.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
}
