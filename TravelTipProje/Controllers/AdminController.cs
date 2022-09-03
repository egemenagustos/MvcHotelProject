using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTipProje.Models.Siniflar;

namespace TravelTipProje.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir",bl);
        }

        public ActionResult BlogGuncelle(Blog p)
        {
            var blg = c.Blogs.Find(p.ID);
            blg.Aciklama = p.Aciklama;
            blg.Baslik = p.Baslik;
            blg.BlogImage = p.BlogImage;
            blg.Tarih = p.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir",yr);
        }
        public ActionResult YorumGuncelle(Yorumlar p)
        {
            var yr = c.Yorumlars.Find(p.ID);
            yr.KullaniciAdi = p.KullaniciAdi;
            yr.Mail = p.Mail;
            yr.Yorum = p.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}