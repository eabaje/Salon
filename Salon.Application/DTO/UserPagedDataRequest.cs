using Salon.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Application.DTO
{
    public class UserPagedDataRequest : PagedDataRequest
    {
        public string RoleName { get; set; }
        public string LastName { get; set; }
        public bool? Active { get; set; }

        public UserSortField SortField { get; set; }
        public SortOrder SortOrder { get; set; }

        public UserPagedDataRequest()
        {
            SortOrder = SortOrder.Ascending;
            SortField = UserSortField.LastName;
        }
    }
}
