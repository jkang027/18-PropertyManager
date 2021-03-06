﻿using PropertyManager.Api.Models;
using System.Collections.Generic;

namespace PropertyManager.Api.Domain
{
    public class Property
    {
        public int PropertyId { get; set; }
        public string UserId { get; set; }
        public int AddressId { get; set; }
        public string PropertyName { get; set; }
        public int? SquareFeet { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfVehicleSpaces { get; set; }

        public virtual PropertyManagerUser User { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
        public virtual ICollection<Lease> Leases { get; set; }
        public virtual Address Address { get; set; }

        public Property()
        {
        }

        public Property(PropertyModel model)
        {
            this.Update(model);
        }

        public void Update(PropertyModel model)
        {
            PropertyId = model.PropertyId;
            AddressId = model.AddressId;
            PropertyName = model.PropertyName;
            SquareFeet = model.SquareFeet;
            NumberOfBedrooms = model.NumberOfBedrooms;
            NumberOfBathrooms = model.NumberOfBathrooms;
            NumberOfVehicleSpaces = model.NumberOfVehicleSpaces;
            Address.Update(model.Address);
        }
    }
}