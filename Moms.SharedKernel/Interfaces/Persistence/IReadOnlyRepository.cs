using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Moms.SharedKernel.Model;

namespace Moms.SharedKernel.Interfaces.Persistence
{
    public interface IReadOnlyRepository<T, in TId> : IDisposable where T : Entity<TId>
    {
        string ConnectionString { get; }

        IQueryable<T> GetAll();
        IQueryable<TC> OrderBy<TC>(IQueryable<TC> source, string orderByValues) where TC : class;
        IQueryable<TC> GetAll<TC, TCId>() where TC : Entity<TCId>;
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        IQueryable<TC> GetAll<TC, TCId>(Expression<Func<TC, bool>> predicate) where TC : Entity<TCId>;
        T GetById(TId id);
        TC GetById<TC, TCId>(TCId id) where TC : Entity<TCId>;
        IEnumerable<TC> ExecQuery<TC>(string selectStatement);
        IDbConnection GetConnection(bool open = true);
        void CloseConnection();
        IEnumerable<T> GetAllOrder(Func<T, bool> predicate,Func<T, object> order,Sorted sorted);
    }
}
