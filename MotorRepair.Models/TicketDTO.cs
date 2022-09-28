using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorRepair.Models
{
  public class TicketDTO
  {
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    [Required]
    public string Status { get; set; }

    public ICollection<WorkItemDTO>? WorkItems { get; set; }
  }
}
