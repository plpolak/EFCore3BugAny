using ErrorAnyEF3.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ErrorAnyEF3
{
    public static class Filter
    {
        public static Expression<Func<T, bool>> GetViewModeFilterCIRMaintenance<T>(int cirId, DbSet<T> others) where T : class, ICIREntity
        {
            /*
            return e => (e.MasterCIRId == cirId)
                     && ((e.MasterCIRId == cirId)
                       && !others.Any(p2 => p2.EntityKey == e.EntityKey && p2.MasterCIRId == cirId));
            */

            var param = Expression.Parameter(typeof(T), "p1");
            //
            // prepare 'exists' check
            var param2 = Expression.Parameter(typeof(T), "p2");
            var checkExp = Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    Expression.Equal(
                        Expression.Property(param2, nameof(ICIREntity.EntityKey)),
                        Expression.Property(param, nameof(ICIREntity.EntityKey))
                    ),
                    Expression.Equal(
                        Expression.Property(param2, nameof(ICIREntity.MasterCIRId)),
                        Expression.Constant(cirId))
                    )
                , param2);

            var anyCall = Expression.Call(typeof(Queryable), nameof(Queryable.Any), new[] { typeof(T) }, Expression.Constant(others), checkExp);
            //
            return Expression.Lambda<Func<T, bool>>(
                      Expression.Or(
                          // CIR data
                          Expression.Equal(
                              Expression.Property(param, nameof(ICIREntity.MasterCIRId)),
                              Expression.Constant(cirId)
                          ),
                          // live and not exists in CIR data
                          Expression.AndAlso(
                              Expression.Equal(
                                  Expression.Property(param, nameof(ICIREntity.MasterCIRId)),
                                  Expression.Constant(cirId)
                              ),
                              Expression.Equal(
                                  anyCall,
                                  Expression.Constant(false)
                              )
                          )
                      ), param);
        }
    }
}
