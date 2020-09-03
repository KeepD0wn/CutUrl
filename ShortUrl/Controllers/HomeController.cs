using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using ShortUrl.Models;

namespace ShortUrl.Controllers
{
    public class HomeController : Controller
    {
        LinksContext context;

        public HomeController(LinksContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {            
            string question = HttpContext.Request.Query["id"].ToString();
            string test = HttpContext.Request.Path;

            if (question != "")
            {
                try
                {
                    Link link = (from x in context.Links
                                 where x.ShortUrl == question
                                 select x).FirstOrDefault();
                    link.Count += 1;
                    context.SaveChanges();
                    Response.Redirect(link.LongURL);
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }

            }
            return View(context.Links.OrderBy(x => x.Id));
        }

        [HttpGet]
        public ActionResult Cut()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cut(Link link)
        {
            if (ModelState.IsValid)
            {
                link.CreatedData = DateTime.Now.ToString();
                link.ShortUrl = DoUrl(6);

                context.Links.Add(link);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        private string DoUrl(int letters)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder(letters);           
            string letterSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            for (int i = 0; i < letters; i++)
                sb.Append(letterSet[rnd.Next(letterSet.Length)]);
            return sb.ToString();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Link link = context.Links.Find(id);

            if (link != null)
            {
                context.Links.Remove(link);
                try
                {                    
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound("Ресурс в приложении не найден");
            }
            Link book = context.Links.Find(id);

            if (book == null)
            {
                return NotFound("Ресурс в приложении не найден");
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Link link)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Entry(link).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }

    }
}
