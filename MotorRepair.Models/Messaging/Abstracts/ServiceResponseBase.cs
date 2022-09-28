using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorRepair.Models.Messaging
{
  public abstract class ServiceResponseBase<T> where T : new()
  {
    public ServiceResponseBase() {
      Data = new T();
      Exception = null;
    }

    public T Data { get; set; }
    public Exception? Exception { get; set; }
  }
}
