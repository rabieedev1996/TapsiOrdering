using Tapsi.Ordering.Application.Contract.SQLDB;
using Tapsi.Ordering.Domain.Entities.SQL;
using Tapsi.Ordering.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Tapsi.Ordering.Infrastructure.SQLRepositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(Context dbContext, DapperContext dapperContext) : base(dbContext, dapperContext)
    {
    }

    public async Task<List<Order>> Filter(DateTime? fromDate, DateTime? toDate,
        int? from=0,int? count=10)
    {
        var query = GetDBSetQuery();
        if (fromDate != null)
        {
            query = query.Where(a => a.CreateDatetime >= fromDate);
        }

        if (toDate != null)
        {
            query=query.Where(a => a.CreateDatetime <= toDate);  
        }
        query=query.OrderByDescending(a=>a.CreateDatetime).Skip(from.Value).Take(count.Value);   
        return  query.ToList();
    }
}