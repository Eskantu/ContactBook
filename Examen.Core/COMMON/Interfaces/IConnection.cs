using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Core.COMMON.Interfaces
{
  public  interface IConnection
    {
        bool Connect();
        object ExecuteQuery(string query);
        int ExecuteNoQuery(string query);
        bool Disconnect();
    }
}
