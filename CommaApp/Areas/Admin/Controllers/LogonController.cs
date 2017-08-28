using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommaApp.CommonUtility;
using CommaApp.BLL;
using CommaApp.DAL;


namespace CommaApp.Areas.Admin.Controllers
{
    public class LogonController : Controller
    {
        //
        // GET: /Admin/Logon/

        public ActionResult Index(string returnurl = "")
        {
            LogonModel model = new LogonModel
            {
                Returnurl = returnurl,
            };

            return View(model);
        }

        public ActionResult Login(LogonModel logonmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UserBLL Userbll = new UserBLL();
                    UserModel adminModel = new UserModel { UserName = logonmodel.UserName, Password = DataEncryption.Encrypt(logonmodel.Password, "passKey") };
                    UserModel objadministrator = Userbll.UserLogin(adminModel);

                    if (adminModel != null)
                    {
                        Session["UserId"] = objadministrator.UserId;
                        Session["UserName"] = objadministrator.UserName;
                        Session["UserTypeId"] = objadministrator.UserTypeId;
                        Session.Timeout = 120;
                        if (logonmodel.Returnurl != null)
                        {
                            return Redirect(logonmodel.Returnurl);
                        }
                        return RedirectToAction("Dashboard", "MasterData");
                    }
                }
                Session["Error"] = "Invalid User name or Password.";
                return View("Index", logonmodel);
            }
            catch (Exception)
            {
                Session["Error"] = "Invalid User name or Password.";
                return View("Index", logonmodel);
                throw;
            }
        }

        public ActionResult Dashboard(string returnurl = "")
        {

            LogonModel model = new LogonModel
            {
                Returnurl = returnurl,
            };
            return View(model);
        }

        public ActionResult Logout()
        {
            try
            {
                Session["UserId"] = string.Empty;
                Session.Abandon();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
                throw;
            }
        }






    }
}