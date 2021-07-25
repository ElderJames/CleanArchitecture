using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public class EFRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : AuditableEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        ApplicationDbContext dbContext;

        public async ValueTask<bool> DeleteAsync(TKey id, CancellationToken cancelationToken)
        {
            var entity = await dbContext.Set<TEntity>().FindAsync(new[] { id }, cancelationToken);
            dbContext.Set<TEntity>().Remove(entity);
            return await dbContext.SaveChangesAsync(cancelationToken) > 0;
        }

        public async ValueTask<TEntity> GetAsync(TKey id, CancellationToken cancelationToken)
        {
            return await dbContext.Set<TEntity>().FindAsync(new[] { id }, cancelationToken);
        }

        public async ValueTask<bool> UpdateAsync(TEntity entity, CancellationToken cancelationToken)
        {
            dbContext.Set<TEntity>().Update(entity);
            return await dbContext.SaveChangesAsync(cancelationToken) > 0;
        }
    }
}
