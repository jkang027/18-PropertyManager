using PropertyManager.Api.Domain;
using System;

namespace PropertyManager.Api.Models
{
    public class WorkOrderModel
    {
        public int WorkOrderId { get; set; }
        public int PropertyId { get; set; }
        public int? TenantId { get; set; }
        public string Description { get; set; }
        public Priorities Priority { get; set; }
        public DateTime OpenedDate { get; set; }
        public DateTime ClosedDate { get; set; }

        public PropertyModel Property { get; set; }
        public TenantModel Tenant { get; set; }
    }
}