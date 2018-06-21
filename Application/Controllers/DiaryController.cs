using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;
using Application.Models.ViewModels;

namespace Application.Controllers
{
    public class DiaryController : Controller
    {
        private DietDBEntities db = new DietDBEntities();

        [HttpGet]
        [AllowOnlyUsers]
        public ViewResult ChooseFood()
        {
            List<DiaryViewModel.ChooseFoodViewModel> model = new List<DiaryViewModel.ChooseFoodViewModel>();
            IQueryable<DiaryViewModel.ChooseFoodViewModel> query = db.Food.Select<Food, DiaryViewModel.ChooseFoodViewModel>(item =>
             new DiaryViewModel.ChooseFoodViewModel()
             {
                 Food = item,
                 AllergyList = item.Allergy.OrderBy(allergy => allergy.Id)
             }
           );

            model = query.ToList();

            return View(model);
        }


        //TODO
        [HttpPost]
        public ViewResult AddMeal(DiaryViewModel.AddMealViewModel model)
        {
            return View(model);
        }
    }
}
