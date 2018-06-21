using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    [AllowOnlyUsers]
    public class MasterDataController : Controller
    {
        private DietDBEntities db = new DietDBEntities();
        // GET: MasterData
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Food.ToList());
        }
    }
}
