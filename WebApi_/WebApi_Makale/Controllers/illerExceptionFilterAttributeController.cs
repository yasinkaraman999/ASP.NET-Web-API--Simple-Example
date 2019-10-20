using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi_Makale.Filters;

namespace WebApi_Makale.Controllers
{
    [EnableCors("*", "*", "*")]//Farklı domain bağlnatı izni.

    [ApiExceptionAttribute]
    public class illerExceptionFilterAttributeController : ApiController
    {
        WebApiTestDatabaseEntities db = new WebApiTestDatabaseEntities();
        public IHttpActionResult Get()
        {
            return Ok(db.Sehir.ToList());
        }
        public IHttpActionResult Get(int? id)
        {

            if (id != null)
            {
                var data = db.Sehir.Find(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest("id Not Found");
                }
            }
            else
            {
                return BadRequest("id Not Found");
            }

        }
        public IHttpActionResult Post(Sehir data)
        {
            if (ModelState.IsValid)
            {
                db.Sehir.Add(data);
                db.SaveChanges();
                return Ok("Post Islemi Basarili.");
            }
            else
            {
                return BadRequest("Post Islemi Basarisiz.");
            }

        }
        public IHttpActionResult Put(Sehir data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Ok("Guncelleme Islemi Basarili.");
            }
            else
            {
                return BadRequest("Guncelleme Islemi Basarisiz.");
            }

        }
        public IHttpActionResult Delete(int? id)
        {
            if (id != null)
            {
                db.Sehir.Remove(db.Sehir.Find(id));
                db.SaveChanges();
                return Ok("Silme Islemi Basarili.");
            }
            else
            {
                return BadRequest("Silme Islemi Basarisiz.");
            }
        }

    }
}
