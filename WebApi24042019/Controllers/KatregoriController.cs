using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi24042019.Models.Entity;
using WebApi24042019.Models.ViewModel;

namespace WebApi24042019.Controllers
{
    public class KatregoriController : ApiController
    {
        NorthwindEntities ctx = new NorthwindEntities();
      
        [HttpGet]
        public List<Kategori> KategoriGetir()
        {
            List<Kategori> katlist = ctx.Kategoriler.Select(x => new Kategori()
            {
                K_ad=x.KategoriAdi,
                K_ack=x.Tanimi
            }).ToList();
            return katlist;
        }


        [HttpGet]
        public Kategori KategoriGetirID(int id)
        {
            Kategoriler kat = ctx.Kategoriler.Find(id);

            Kategori katmodel = new Kategori();
            katmodel.K_ad = kat.KategoriAdi;
            katmodel.K_ack = kat.Tanimi;
            return katmodel;
        }

        [HttpPost]
        public IHttpActionResult KategoriEkle(Kategori model)
        {
            Kategoriler kat = new Kategoriler()
            {
                KategoriAdi = model.K_ad,
                Tanimi = model.K_ack
            };

            ctx.Kategoriler.Add(kat);
            ctx.SaveChanges();
            return Json("basarili");
        }


    }
}
