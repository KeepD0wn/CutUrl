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
using MySql.Data.MySqlClient;

namespace ShortUrl.Controllers
{
    public class HomeController : Controller
    {
         LinksContext context;

        public HomeController(LinksContext context)
        {
            this.context = context;
        }

        [Route("{url}")]
        public void Index2(string url)
        {
            Link link = (from x in context.Links
                         where x.ShortUrl == url
                         select x).FirstOrDefault();
            if (link != null) //если есть запись в БД с таким же ShortUrl
            {
                link.Count += 1;
                context.SaveChanges();
                Response.Redirect(link.LongURL);
            }
            else
            {
                Response.Redirect("Home/Index");
            }
           
        }

        public ActionResult Index(string id)
        {                        
            context.Database.EnsureCreated();
            ViewBag.url = HttpContext.Request.Scheme+ "://" +""+HttpContext.Request.Host.ToString()+ "/";
            //передаём строку текущего Url, что бы к ней добавить параметр id
           
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
                return RedirectToAction("Index");
            }
            Link link = context.Links.Find(id);
            ViewBag.currentSU = link.ShortUrl;

            if (link == null)
            {
                return RedirectToAction("Index");
            }
            return View(link);
        }

        [HttpPost]
        public ActionResult Edit(Link link,int id)                         
        {           
            if (ModelState.IsValid) //проверка на ошибки в аттрибутах модели
            {               
                try
                {
                    Link previousLink = context.Links.Find(id);
                    ViewBag.currentSU = previousLink.ShortUrl;

                    if (previousLink.ShortUrl != link.ShortUrl) //если изменили шортюрл, то меняем его
                    {
                        previousLink.ShortUrl = link.ShortUrl;
                    }
                    else if (previousLink.LongURL != link.LongURL) //если шортюрл не меняли, но поменяли юрл, то меняем шортюрл на рандом
                    {                        
                        previousLink.ShortUrl = DoUrl(7);
                    }                   
                    
                    previousLink.LongURL = link.LongURL;                    

                    Link link1 = (from x in context.Links
                                 where x.ShortUrl == previousLink.ShortUrl
                                 select x).FirstOrDefault();                   

                    if (link1==null) //если получается, что таких ShortUrl нет в БД, то сохраняем
                    {                        
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    
                    return View(link);

                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index");
                }                
            }
            else
            {
                return View();
            }
            
        }

    }
}
