using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();

        // GET: SosyalMedya
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();

        }


        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x => x.ID == id);

            return View(hesap);

        }

        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalMedya t)
        {
            var hesap = repo.Find(x => x.ID == t.ID);
            hesap.Ad = t.Ad;
            hesap.Durum = true;
            hesap.Link = t.Link;
            hesap.ikon = t.ikon;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");

        }

        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}