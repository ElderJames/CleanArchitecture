using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common
{
    public interface IRepository<TEntity, TKey>
        where TEntity : AuditableEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        ValueTask<TEntity> GetAsync(TKey id, CancellationToken cancelationToken);

        ValueTask<bool> UpdateAsync(TEntity entity, CancellationToken cancelationToken);

        ValueTask<bool> DeleteAsync(TKey id, CancellationToken cancelationToken);
    }
}
