using DWS_Projekat.Data;
using DWS_Projekat.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWS_Projekat.Controllers
{
    public class ObjavaController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
           
        public ObjavaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int id)
        {
            var objava = _dbContext.Objave.FirstOrDefault(x => x.Id == id);
            var komentari = _dbContext.Replies.Where(x => x.Objavaid == id);
            ViewBag.objava = objava;
            ViewBag.komentari = komentari;
            return View();
        }

        [HttpPost]
        public IActionResult NapisiKomentar(int idobjave,string content)
        {
            var povrat = new Reply();
            povrat.Autor = this.HttpContext.User.Identity.Name;
            povrat.tekst = content;
            povrat.Objavaid = idobjave;

            _dbContext.Replies.Add(povrat);
            _dbContext.SaveChanges();
            return RedirectToAction("Index",new { id = idobjave });
        }

        [HttpPost]
        public IActionResult ObrisiKomentar(int idkomentara,int idobjave)
        {
            var page = _dbContext.Replies.FirstOrDefault(x => x.Id == idkomentara);
            _dbContext.Replies.Remove(page);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", new { id = idobjave });
        }
    }
}
