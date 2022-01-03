using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jachty.Models;

namespace Jachty.Controllers
{
    public class JachtyController : Controller
    {
        // GET: Jachty

        public ActionResult Home()
        {

           return View();
        }

        public ActionResult ShowMorskie()
        {

            // var jacht = new Jacht() { Nazwa = "Jacht1" };
            //  return View(jacht);
            return View();
        }

        public ActionResult ShowLadowe()
        {
            return View();
        }

    }
}