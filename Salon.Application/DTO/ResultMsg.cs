using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Application.DTO
{
  public  class ResultMsg
    {
        public bool IsSuccess { get; set; }
        public Guid ResultId { get; set; }
        public string Msg { get; set; }
    }
}
