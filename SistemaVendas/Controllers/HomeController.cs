﻿using HtmlAgilityPack;
using NHibernate;
using SistemaVendas.Models;
using SistemaVendas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebCrawler;

namespace SistemaVendas.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ISession session) : base(session)
        {
        }
    //    HtmlDocument doc;

        public ActionResult Index()
        {
            var a = new NetCoders();
            var b = new PagSeguro();
          //  b.CheckOut();
          //  a.CarregaPosts();
            //string titulo;
            //using (WebClient client = new WebClient())
            //{
            //    var html = client.htt("https://www.zoom.com.br/notebook?q=notebook&resultsperpage=72");
            //    doc.LoadHtml(html);
            //}

            ////Titulo
            //HtmlNode no = doc.DocumentNode.SelectSingleNode("//div[@id='dvTitulo']/h1[@class='titdestaque']");
            //titulo = no.InnerText;

            return View();
        }

        public JsonResult GetUser(long id)
        {
            var x = new JsonResult();
            x.Data = _session.Get<Pessoa>(id);
            return Json(x, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logar(string login, string senha)
        {
            var result = new JsonResult();
            var vendedor = _session.Query<Vendedor>().Where(x => x.Login.ToLower() == login.ToLower() && x.Senha == senha).FirstOrDefault();
            if (vendedor != null)
            {
                result.Data = true;
                result.ContentType = "/PainelGeral/Index";
            }
            else
            {
                result.Data = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUsers()
        {
            var x = new JsonResult();
            x.Data = _session.Query<Pessoa>();
            return Json(x, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}