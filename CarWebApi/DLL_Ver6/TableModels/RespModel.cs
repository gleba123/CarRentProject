using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Ver6.TableModels
{
  public  class RespModel
    {
        public bool IsSuccess { get; set; }
        public string error { get; set; }
        public object RespObject { get; set; }
    }
}
