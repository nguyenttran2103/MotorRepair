using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorRepair.Models.Messaging
{
  public abstract class ServiceRequestBase<T> where T : new()
  {
    public T Payload { get; set; }
  }
}
