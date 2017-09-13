using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommaApp.BLL;
using CommaApp.CommonUtility;
using CommaApp.Filters;

namespace CommaApp.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        //
        // GET: /Admin/UserType/
        UserTypeBLL usertypeBLL = new UserTypeBLL();
        
        //
        // GET: /Admin/Role/

        public ActionResult Index(int pid = 0)
        {
            try
            {
                int take = 10;
                int skip = take * pid;
                UserTypeModel UsertypeModel = new UserTypeModel();
                UsertypeModel.PageID = pid;
                UsertypeModel.Current = pid + 1;

                var rolelist = new UserTypeBLL { }.GetAllUserTypes(skip, take);
                if (rolelist != null)
                {
                    double count = Convert.ToDouble(new UserTypeBLL { }.GetPageCount());
                    var res = count / take;
                    UsertypeModel.Pagecount = (int)Math.Ceiling(res);
                    UsertypeModel.UserTypeList = rolelist;
                }
                CustomMethods.ValidateRoles("Role");
                return View(UsertypeModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult Create()
        {
            UserTypeModel model = new UserTypeModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserTypeModel model, FormCollection Pages)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = Convert.ToInt32(Session["UserId"]);
                    int res = new UserTypeBLL { }.AddEditUserType(model);
                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("Index");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public ActionResult Edit(int id, int pid = 0)
        {
            try
            {
                UserTypeModel model = usertypeBLL.GetUserTypeById(id);
                int take = 10;
                int skip = take * pid;
                model.PageID = pid;
                model.Current = pid + 1;
                ViewBag.c = model.PageID;
                if (model != null)
                {
                    return View(model);
                }
                Session["Error"] = "Record does not exist";
                return View(new UserTypeModel());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult Edit(UserTypeModel model, FormCollection Pages)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedBy = Convert.ToInt32(Session["UserId"]);
                    int res = new UserTypeBLL { }.AddEditUserType(model);
                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Updated";
                        return RedirectToAction("Index");
                    }
                }
                Session["Error"] = "An Error has occured";
                return View(model);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public JsonResult ChangeStatusUserType(int id)
        {
            bool Result = false;
            bool changestatus = new UserTypeBLL { }.ChangeStatusUserType(id);
            if (changestatus)
            {
                Result = true;

            }
            return Json(Result);
        }

        public ActionResult ViewUserType(int id, int pid = 0)
        {
            try
            {
                UserTypeModel model = new UserTypeBLL { }.GetUserTypeById(id);
                int take = 10;
                int skip = take * pid;
                model.PageID = pid;
                model.Current = pid + 1;
                ViewBag.c = model.PageID;
                return View(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
