using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorRepair.Repository.Entities
{
  public class Ticket
  {
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public string Status { get; set; }

    public virtual ICollection<WorkItem> WorkItems { get; set; }
  }
}
