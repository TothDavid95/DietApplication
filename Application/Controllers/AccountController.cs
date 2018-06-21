using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Application.Models;

namespace Application.Controllers
{
    public class AccountController : Controller
    {
        private DietDBEntities db = new DietDBEntities();

        [AllowOnlyAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowOnlyAnonymous]
        public ActionResult Register(Models.ViewModels.AccountViewModel.RegisterViewModel user)
        {
            if (ModelState.IsValidField("UserName") && ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
            {
                user.Password = HashIt(user.UserName + user.Password);

                User userToDB = new User()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password
                };
                db.User.Add(userToDB);
                db.SaveChanges();
                TempData["Message"] = $"{user.UserName}, sikeres regisztráció.";
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [AllowOnlyAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowOnlyAnonymous]
        public ActionResult Login(Models.ViewModels.AccountViewModel.LoginViewModel userTryingToLogIn)
        {
            if (ModelState.IsValid)
            {
                User actualUser = db.User.Where(u => u.UserName == userTryingToLogIn.UserName).FirstOrDefault();
                if (actualUser != null)
                {
                    string hashedLoginPassword = HashIt(userTryingToLogIn.UserName + userTryingToLogIn.Password);
                    bool loginSuccess = hashedLoginPassword.Equals(actualUser.Password.Replace(" ", ""));
                    if (loginSuccess)
                    {
                        Session["username"] = actualUser.UserName;
                        Session["userID"] = actualUser.Id;
                        List<int> allergyIDs = new List<int>();
                        foreach (var allergy in actualUser.Allergy)
                        {
                            allergyIDs.Add(allergy.Id);
                        }
                        Session["allergyIDList"] = allergyIDs;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.errorMessage = "Login failed";
                        return View();
                    }
                }
            }
            ViewBag.errorMessage = $"Felhasználó '{userTryingToLogIn.UserName}' nem létezik.";
            return View();
        }

        [HttpGet]
        [AllowOnlyUsers]
        public ActionResult Details()
        {
            int id = Int32.Parse(Session["userID"].ToString());
            User user = db.User.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        [HttpGet]
        [AllowOnlyUsers]
        public ActionResult Edit()
        {
            int id = Int32.Parse(Session["userID"].ToString());
            User user = db.User.Where(u => u.Id == id).FirstOrDefault();

            Models.ViewModels.AccountViewModel.EditViewModel model = new Models.ViewModels.AccountViewModel.EditViewModel
            {
                Allergies = new int[user.Allergy.Count],
                Email = user.Email
            };

            List<Allergy> userAllergyList = user.Allergy.ToList();
            for (int i = 0; i < model.Allergies.Length; i++)
            {
                model.Allergies[i] = userAllergyList[i].Id;
            }

            //ViewDataDictionary needs DefaultAllergies to draw it properly
            ViewData["DefaultAllergies"] = HelperMethods.GetDefaultAllergies(db);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowOnlyUsers]
        public String Edit(Models.ViewModels.AccountViewModel.EditViewModel model)
        {
            User userInDB;
            using (DbContextTransaction tran = db.Database.BeginTransaction())
            {
                int id;
                try
                {
                    id = Int32.Parse(Session["userID"].ToString());
                    userInDB = db.User.Include(u => u.Allergy).First(u => u.Id == id);
                    userInDB.Allergy = new HashSet<Allergy>();
                    if (model.Email != null)
                    {
                        userInDB.Email = model.Email;
                    }
                    if (model.Allergies.Length != 0)
                    {
                        AddAllergies(userInDB, model.Allergies);
                        TempData["allergyIDList"] = model.Allergies.ToList();
                    }
                    db.SaveChanges();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    id = Int32.Parse(Session["userID"].ToString());
                    userInDB = db.User.Single(u => u.Id == id);
                }
            }
            ViewData["DefaultAllergies"] = HelperMethods.GetDefaultAllergies(db);
            return "success";
        }

        [AllowOnlyUsers]
        public ActionResult Logout()
        {
            Session["username"] = null;
            Session["userID"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public string UniqueUsernameValidation(string[] uname)
        {
            string un = uname[0];
            return db.User.Count(u => u.UserName == un) != 0 ? "taken" : "unused";
        }

        [HttpPost]
        public string UnusedEmailValidation(string[] email)
        {
            string em = email[0];
            return db.User.Count(u => u.Email == em) != 0 ? "used" : "unused";
        }

        private string HashIt(string stringToHash)
        {
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(stringToHash);
            byteArray = (new System.Security.Cryptography.SHA256CryptoServiceProvider()).ComputeHash(byteArray);
            StringBuilder sb = new System.Text.StringBuilder();
            foreach (var @byte in byteArray)
            {
                sb.Append(@byte.ToString("x2"));
            }
            return sb.ToString();
        }

        private void AddAllergies(User user, int[] allergyIdArray)
        {
            List<Allergy> defaultAllergies = HelperMethods.GetDefaultAllergies(db);
            for (int i = 0; i < allergyIdArray.Length; i++)
            {
                user.Allergy.Add(defaultAllergies[allergyIdArray[i]]);
            }
        }
    }
}
