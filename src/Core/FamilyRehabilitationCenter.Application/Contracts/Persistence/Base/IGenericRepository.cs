using System.Linq.Expressions;

namespace FamilyRehabilitationCenter.Application.Contracts.Persistence.Base
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task<Entity?> GetByIdAsync(int id);
        Task<List<Entity>> GetAllAsNoTracking();
        IQueryable<Entity> GetAllAsTracking();
        Task AddRangeAsync(ICollection<Entity> entities);
        Task AddAsync(Entity entity);
        Task UpdateRangeAsync<TProperty>(Func<Entity, TProperty> propertyExpression, Func<Entity, TProperty> valueExpression);
        Task DeleteRangeAsync(Expression<Func<Entity, bool>> predicate);
        void Delete(Entity entity);

    }
}
