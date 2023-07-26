using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Extensions
{
    /// <summary>
    /// In developing
    /// </summary>
    public static class IQueryableExtension
    {
        public static IQueryable<T> Filtering<T>(this IQueryable<T> source, Expression<Func<T, bool>> expression)
        {
            return source.Where(expression);
        }

        public static IQueryable<T> Paging<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            return source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
