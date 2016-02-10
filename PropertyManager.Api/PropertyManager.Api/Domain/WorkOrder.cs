using PropertyManager.Api.Models;
using System;

namespace PropertyManager.Api.Domain
{
    public enum Priorities
    {
        Urgent = 1,
        High = 2,
        Moderate = 3,
        Low = 4
    }

    public class WorkOrder
    {
        public int WorkOrderId { get; set; }
        public int PropertyId { get; set; }
        public int? TenantId { get; set; }
        public string Description { get; set; }
        public Priorities Priority { get; set; }
        public DateTime OpenedDate { get; set; }
        public DateTime? ClosedDate { get; set; }

        public virtual Property Property { get; set; }
        public virtual Tenant Tenant { get; set; }

        public WorkOrder()
        {
        }

        public WorkOrder(WorkOrderModel model)
        {
            this.Update(model);
        }

        public void Update(WorkOrderModel model)
        {
            WorkOrderId = model.WorkOrderId;
            PropertyId = model.PropertyId;
            TenantId = model.TenantId;
            Description = model.Description;
            Priority = model.Priority;
            OpenedDate = model.OpenedDate;
            ClosedDate = model.ClosedDate;
        }
    }
}