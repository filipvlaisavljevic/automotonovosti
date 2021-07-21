using DWS_Projekat.Data;
using DWS_Projekat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWS_Projekat.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(ApplicationDbContext dbContext,RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectRole role)
        {
            var roleExist = await roleManager.RoleExistsAsync(role.RoleName);
            if (!roleExist)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(role.RoleName));
            }
            return View();
        }

        public IActionResult DodajNovost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SacuvajNovost(string title,string slika,string content)
        {
            var page = new Objava();

            page.Title = title;
            page.Content = content;
            page.Autor = this.HttpContext.User.Identity.Name;
            page.Slika = slika;

            _dbContext.Objave.Add(page);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult UrediObjavu(int id)
        {
            var page = _dbContext.Objave.FirstOrDefault(x => x.Id == id);
            return View(page);
        }

        [HttpPost]
        public IActionResult SacuvajObjavu(int id, string autor, string slika,string title, string content)
        {
            var page = _dbContext.Objave.FirstOrDefault(x => x.Id == id);
            page.Autor = autor;
            page.Content = content;
            page.Slika = slika;
            page.Title = title;

            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ObrisiObjavu(int id)
        {
            var page = _dbContext.Objave.FirstOrDefault(x => x.Id == id);
            _dbContext.Objave.Remove(page);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
