using Salon.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Application.DTO
{
    public class TraceLogPagedDataRequest : PagedDataRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
        public string PerformedBy { get; set; }
        public TraceLogSortField SortField { get; set; }
        public SortOrder SortOrder { get; set; }

        public TraceLogPagedDataRequest()
        {
            SortOrder = SortOrder.Descending;
            SortField = TraceLogSortField.PerformedOn;
        }
    }

    public enum TraceLogSortField
    {
        Id,
        Controller,
        Action,
        Message,
        PerformedOn,
        PerformedBy
    }
}

