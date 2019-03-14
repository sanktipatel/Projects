using MyCart.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MyCart.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login objUser)
        {
            if (ModelState.IsValid)
            {
                using (MyCartContext db = new MyCartContext())
                {
                    var obj = db.LoginDetails.Where(a => a.ID == objUser.ID && a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.ID.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        //FormsAuthentication.SetAuthCookie(objUser.UserName,objUser.RememberMe);

                        return RedirectToAction("Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login data is incorrect!");
                    }
                }
            }
            return View(objUser);
        }

        
        public ActionResult Home()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}