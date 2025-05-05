using Tapsi.Ordering.Application.Contract.Database.SQLDB;
using Tapsi.Ordering.Domain.Entities.SQL;

namespace Tapsi.Ordering.Application.Contract.SQLDB;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<List<Order>> Filter(DateTime? fromDate, DateTime? toDate,
        int? from = 0, int? count = 10);
}