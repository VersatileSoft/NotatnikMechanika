using NotatnikMechanika.Data.Models;
using System.Linq;

namespace NotatnikMechanika.Repository
{
    public static class Extensions
    {
        public static IQueryable<T> OwnedByUser<T>(this IQueryable<T> query, string userId) where T : EntityBase
        {
            if (!string.IsNullOrEmpty(userId))
            {
                return query.Where(e => e.UserId == userId);
            }

            return query;
        }
    }
}
