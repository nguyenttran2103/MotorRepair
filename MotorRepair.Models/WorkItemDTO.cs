using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorRepair.Models
{
  public class WorkItemDTO
  {
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    public Double Price { get; set; }
    public double? Hours { get; set; }
    public int? Quantity { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public int TicketId { get; set; }
    public TicketDTO? Ticket { get; set; }
  }
}
