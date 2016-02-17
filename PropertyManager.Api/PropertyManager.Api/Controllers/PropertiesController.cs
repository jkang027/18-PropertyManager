using AutoMapper;
using PropertyManager.Api.Domain;
using PropertyManager.Api.Infrastructure;
using PropertyManager.Api.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace PropertyManager.Api.Controllers
{
    [Authorize]
    public class PropertiesController : ApiController
    {
        private PropertyManagerDataContext db = new PropertyManagerDataContext();

        // GET: api/Properties
        public IEnumerable<PropertyModel> GetProperties()
        {
            return Mapper.Map<IEnumerable<PropertyModel>>(db.Properties.Where(p => p.User.UserName == User.Identity.Name));
        }

        // GET: api/Properties/5
        [ResponseType(typeof(Property))]
        public IHttpActionResult GetProperty(int id)
        {
            Property property = db.Properties.FirstOrDefault(p => p.User.UserName == User.Identity.Name && p.PropertyId == id);

            if (property == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<PropertyModel>(property));
        }

        // GET: api/Properties/5/WorkOrders
        [Route("api/properties/{propertyId}/workorders")]
        public IEnumerable<WorkOrderModel> GetWorkOrdersForProperty(int propertyId)
        {
            Property properties = db.Properties.FirstOrDefault(p => p.User.UserName == User.Identity.Name && p.PropertyId == propertyId);

            return Mapper.Map<IEnumerable<WorkOrderModel>>(properties);
        }

        // GET: api/Properties/5/Leases
        [Route("api/properties/{propertyId}/leases")]
        public IEnumerable<LeaseModel> GetLeasesForProperty(int propertyId)
        {
            Property properties = db.Properties.FirstOrDefault(p => p.User.UserName == User.Identity.Name && p.PropertyId == propertyId);

            return Mapper.Map<IEnumerable<LeaseModel>>(properties);
        }

        // PUT: api/Properties/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProperty(int id, PropertyModel property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != property.PropertyId)
            {
                return BadRequest();
            }

            #region Thing to change

            Property dbProperty = db.Properties.FirstOrDefault(p => p.User.UserName == User.Identity.Name && p.PropertyId == id);

            if(dbProperty == null)
            {
                return BadRequest();
            }

            dbProperty.Update(property);
            db.Entry(dbProperty).State = EntityState.Modified;

            #endregion Thing to change

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Properties
        [ResponseType(typeof(Property))]
        public IHttpActionResult PostProperty(PropertyModel property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbProperty = new Property(property);

            dbProperty.User = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            db.Properties.Add(dbProperty);
            db.SaveChanges();

            property.PropertyId = dbProperty.PropertyId;

            return CreatedAtRoute("DefaultApi", new { id = property.PropertyId }, property);
        }

        // DELETE: api/Properties/5
        [ResponseType(typeof(Property))]
        public IHttpActionResult DeleteProperty(int id)
        {
            Property property = db.Properties.FirstOrDefault(p => p.User.UserName == User.Identity.Name && p.PropertyId == id);
            if (property == null)
            {
                return NotFound();
            }

            db.Properties.Remove(property);
            db.SaveChanges();

            return Ok(Mapper.Map<PropertyModel>(property));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropertyExists(int id)
        {
            return db.Properties.Count(e => e.PropertyId == id) > 0;
        }
    }
}