using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Application.DTO
{
    public abstract class PagedDataRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        protected PagedDataRequest()
        {
            PageIndex = 0;
            PageSize = 2147483647;
        }
    }
}
