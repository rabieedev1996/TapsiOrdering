using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapsi.Ordering.Domain.Enums;

namespace Tapsi.Ordering.Domain.Entities.SQL
{
    public class Order : EntityBase
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public OrderStatusTypes OrderStatus { get; set; }
        public decimal TotalPrice { set; get; }
    }
}
