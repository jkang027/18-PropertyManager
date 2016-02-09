﻿using PropertyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.Api.Domain
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public bool International { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }

        public Address()
        {

        }

        public Address(AddressModel model)
        {
            this.Update(model);
        }

        public void Update(AddressModel model)
        {
            AddressId = model.AddressId;
            Address1 = model.Address1;
            Address2 = model.Address2;
            Address3 = model.Address3;
            Address4 = model.Address4;
            Address5 = model.Address5;
            City = model.City;
            Region = model.Region;
            PostalCode = model.PostalCode;
            International = model.International;
        }
    }
}