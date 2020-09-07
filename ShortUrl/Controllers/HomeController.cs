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

        public ActionResult Index(string id)
        {
            string question = HttpContext.Request.Query["id"].ToString();
            ViewBag.url = HttpContext.Request.Scheme+ "://" +""+HttpContext.Request.Host.ToString()+ "/?id=";
            //передаём строку текущего Url, что бы к ней добавить параметр id

            if (question != "")
            {
                try
                {
                    Link link = (from x in context.Links
                                 where x.ShortUrl == question
                                 select x).FirstOrDefault();
                    if (link != null) //если есть запись в БД с таким же ShortUrl
                    {
                        link.Count += 1;
                        context.SaveChanges();
                        Response.Redirect(link.LongURL);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }

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
            if (ModelState.IsValid) //проверка на ошибки в аттрибутах модели
            {
                link.CreatedData = DateTime.Now.ToString();
                link.ShortUrl = DoUrl(7);

                Link link1 = (from x in context.Links
                             where x.ShortUrl == link.ShortUrl
                              select x).FirstOrDefault();
                if (link1!=null) //если нашли запись с таким же ShortUrl, то перерандомим
                {
                    while (link1.ShortUrl == link.ShortUrl)
                    {
                        link.ShortUrl = DoUrl(7);
                    }
                }
                
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
            Link link = context.Links.Find(id);

            if (link == null)
            {
                return NotFound("Ресурс в приложении не найден");
            }
            return View(link);
        }

        [HttpPost]
        public ActionResult Edit(Link link)
        {
            if (ModelState.IsValid) //проверка на ошибки в аттрибутах модели
            {               
                try
                {
                    context.Entry(link).State = EntityState.Modified;

                    Link link1 = (from x in context.Links
                                 where x.ShortUrl == link.ShortUrl
                                 select x).FirstOrDefault();

                    if (link1==null) //если получается, что таких ShortUrl нет в БД, то сохраняем
                    {
                        context.SaveChanges();
                    }
                    
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index");
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
