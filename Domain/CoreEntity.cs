using System.ComponentModel.DataAnnotations.Schema;

namespace Tenant.Domain;

[NotMapped]
public class CoreEntity 
{
    [Column("status")]
    public bool? Status { get; set; }
    [Column("insert_date")]
    public DateTime? InsertDate { get; set; }
    [Column("update_date")]
    public DateTime? UpdateDate { get; set; }
    [Column("insert_user")]
    public int? InsertUser { get; set; }
    [Column("update_user")]
    public int? UpdateUser { get; set; }
}