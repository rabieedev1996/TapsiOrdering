using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tapsi.Ordering.Domain.Entities.SQL;

public class EntityBase
{
    public long Id { set; get; }
    public DateTime CreateDatetime { set; get; }
    [StringLength(30)]
    public string JalaliCreatedAt { set; get; }
    public bool IsDeleted { set; get; }
    public long JalaliDateKey { set; get; }
    public DateTime? ModifyDate { set; get; }
}