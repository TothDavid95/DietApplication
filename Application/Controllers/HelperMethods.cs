using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.Models;

namespace Application.Controllers
{
    public class HelperMethods
    {
        public static List<Allergy> GetDefaultAllergies(DietDBEntities db)
        {
            return db.Allergy.ToList();
        }
    }
}