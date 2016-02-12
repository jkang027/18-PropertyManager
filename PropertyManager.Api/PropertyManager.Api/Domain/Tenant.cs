using PropertyManager.Api.Models;
using System.Collections.Generic;

namespace PropertyManager.Api.Domain
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public int? AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
        public virtual ICollection<Lease> Leases { get; set; }
        public virtual Address PriorAddress { get; set; }

        public Tenant()
        {
        }

        public Tenant(TenantModel model)
        {
            Update(model);
        }

        public void Update(TenantModel model)
        {
            TenantId = model.TenantId;
            AddressId = model.AddressId;
            FirstName = model.FirstName;
            LastName = model.LastName;
            PhoneNumber = model.PhoneNumber;
            EmailAddress = model.EmailAddress;
            PriorAddress.Update(model.PriorAddress);
        }
    }
}