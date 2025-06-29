using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();
        // GET: Hobi
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Index(TblHakkimda p)
        {
            var hakkimda = repo.Find(x => x.ID == 1);
            hakkimda.Ad = p.Ad;
            hakkimda.Soyad = p.Soyad;
            hakkimda.Adres = p.Adres;
            hakkimda.Mail = p.Mail;
            hakkimda.Telefon = p.Telefon;
            hakkimda.Aciklama = p.Aciklama;
            hakkimda.Resim = p.Resim;
            repo.TUpdate(hakkimda);
            return RedirectToAction("Index");
        }
    }

}