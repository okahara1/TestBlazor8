using System;
using System.Linq;
using System.Linq.Expressions;

namespace TestBlazor8.Shared
{
    public static class CustomExtension
    {
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> Source, bool Condition, Expression<Func<TSource, bool>> Predicate)
        {
            if (Condition)
            {
                return Source.Where(Predicate);
            }
            else
            {
                return Source;
            }
        }
    }
}
