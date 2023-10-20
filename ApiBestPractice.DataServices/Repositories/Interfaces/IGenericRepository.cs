﻿using ApiBestPractice.Entities.Entities;

namespace ApiBestPractice.DataServices.Repositories.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> All();
    Task<T?> GetById(Guid id);
    Task<bool> Create(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(Guid id);
}