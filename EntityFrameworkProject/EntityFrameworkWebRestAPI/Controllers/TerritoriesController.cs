using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EntityFrameworkWebRestAPI.Models;
using EntityFrameworkWebRestAPI.Models.DTOs;
using Newtonsoft.Json;

namespace EntityFrameworkWebRestAPI.Controllers
{
    public class TerritoriesController : ApiController
    {
        private Model1 db = new Model1();

        private static readonly Expression<Func<Territories, TerritoryDTO>> AsTerritoryDTO =
            x => new TerritoryDTO
            {
                TerritoryID = x.TerritoryID,
                TerritoryDescription = x.TerritoryDescription,
                RegionID = x.RegionID
            };

        // GET: api/Territories
        public IQueryable<TerritoryDTO> GetTerritories()
        {
            return db.Territories.Select(AsTerritoryDTO);
        }

        // GET: api/Territories/5
        [ResponseType(typeof(Territories))]
        public IHttpActionResult GetTerritories(string id)
        {
            TerritoryDTO territories = db.Territories.Where(t => t.TerritoryID == id).Select(AsTerritoryDTO).FirstOrDefault();
            if (territories == null)
            {
                return NotFound();
            }

            return Ok(territories);
        }

        // PUT: api/Territories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTerritories(string id, Territories territories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != territories.TerritoryID)
            {
                return BadRequest();
            }

            db.Entry(territories).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerritoriesExists(id))
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

        // POST: api/Territories
        [ResponseType(typeof(Territories))]
        public IHttpActionResult PostTerritories(Territories territories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Territories.Add(territories);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TerritoriesExists(territories.TerritoryID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = territories.TerritoryID }, territories);
        }

        // DELETE: api/Territories/5
        [ResponseType(typeof(Territories))]
        public IHttpActionResult DeleteTerritories(string id)
        {
            Territories territories = db.Territories.Find(id);
            if (territories == null)
            {
                return NotFound();
            }

            db.Territories.Remove(territories);
            db.SaveChanges();

            return Ok(territories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TerritoriesExists(string id)
        {
            return db.Territories.Count(e => e.TerritoryID == id) > 0;
        }
    }
}