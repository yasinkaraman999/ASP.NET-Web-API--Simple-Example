using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi_Makale.Controllers
{
    [EnableCors("*", "*", "*")]//Farklı domain bağlnatı izni.
    public class illerHttpResponseController : ApiController
    {
        WebApiTestDatabaseEntities db = new WebApiTestDatabaseEntities();
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK,db.Sehir);
        }
        public HttpResponseMessage Get(int? id)
        {
            
            if (id!=null)
            {
                var data = db.Sehir.Find(id);
                if (data!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,"id Not Found");
                }
                
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
          
        }
        public HttpResponseMessage Post(Sehir data)
        {
            if (ModelState.IsValid)
            {
                db.Sehir.Add(data);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Post Islemi Basarili.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,"Post Islemi Basarisiz.");
            }
           
        }
        public HttpResponseMessage Put(Sehir data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Guncelleme Islemi Basarili.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Guncelleme Islemi Basarisiz.");
            }
          
        }
        public HttpResponseMessage Delete(int? id)
        {
            if (id!=null)
            {
                db.Sehir.Remove(db.Sehir.Find(id));
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Silme Islemi Basarili.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Silme Islemi Basarisiz.");
            }
          
        }

    }
}
