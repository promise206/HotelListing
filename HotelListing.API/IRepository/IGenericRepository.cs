﻿using System.Linq.Expressions;

namespace HotelListing.API.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll(
            Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> Includes = null
            );
        Task<T> Get(Expression<Func<T, bool>> expression, List<string>  includes = null);
        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> entities);
        Task Delete(int Id);
        void DeleteRange(IEnumerable<T> entities);  
        void Update(T entity);
    }
}
