using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CabaVS.Shared.Extensions.EFCore
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyInclude<T>(this IQueryable<T> expression, string[] includes, bool isOptional = true) where T : class
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            if (!isOptional && includes == null) throw new ArgumentNullException(nameof(includes));

            return includes != null && includes.Length > 0
                ? includes.Aggregate(expression,
                    (current, navigationPropertyPath) => current.Include(navigationPropertyPath))
                : expression;
        }
    }
}