﻿using Microsoft.EntityFrameworkCore;
using Server.Domain.Abstractions;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;
using System.Linq.Expressions;

namespace Server.Infrastructure.Repositories;

public class CommandRepository<T> : ICommandRepository<T> where T : Entity
{
    protected readonly AppDbContext context;

    public CommandRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(entity, cancellationToken);
    }

    public void Delete(T entity)
    {
        context.Remove(entity);
    }

    public void Update(T entity)
    {
        context.Update(entity);
    }
}

public class QueryRepository<T> : IQueryRepository<T> where T : Entity
{
    protected readonly AppDbContext context;

    public QueryRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = context.Set<T>();

        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<T> GetByAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = context.Set<T>().Where(filter);

        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.FirstOrDefaultAsync(cancellationToken) ?? default!;
    }

    public IQueryable<T> QueryAll()
    {
        IQueryable<T> query = context.Set<T>();

        return query.AsQueryable();
    }
}
