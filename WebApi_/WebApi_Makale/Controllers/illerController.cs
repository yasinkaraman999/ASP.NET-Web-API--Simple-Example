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
    public class illerController : ApiController
    {
        WebApiTestDatabaseEntities db = new WebApiTestDatabaseEntities();
        public IEnumerable<Sehir> Get()
        {
            return db.Sehir;
        }
        public Sehir Get(int id)
        {
            return db.Sehir.Find(id);
        }
        public Sehir Post(Sehir data)
        {
            if (ModelState.IsValid)
            {
                db.Sehir.Add(data);
                db.SaveChanges();

            }
            return data;
        }
        public bool Put(Sehir data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
          
        }
        public bool Delete(int? id)
        {
            if (id!=null)
            {
                db.Sehir.Remove(db.Sehir.Find(id));
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
          
        }

    }
}
