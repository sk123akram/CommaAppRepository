using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommaApp.BLL;
using CommaApp.CommonUtility;
using CommaApp.Filters;
using CommaApp.DAL;
using System.Xml.Linq;

namespace CommaApp.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        RolesBLL objRolesBLL = new RolesBLL();

        //
        // GET: /Admin/Role/

        public ActionResult Index(int pid = 0)
        {
            try
            {
                int take = 10;
                int skip = take * pid;
                RoleModal objRoleModal = new RoleModal();
                objRoleModal.PageID = pid;
                objRoleModal.Current = pid + 1;

                var rolelist = new RolesBLL { }.GetAllRoles(skip, take);
                if (rolelist != null)
                {
                    double count = Convert.ToDouble(new RolesBLL { }.GetPageCount());
                    var res = count / take;
                    objRoleModal.Pagecount = (int)Math.Ceiling(res);
                    objRoleModal.Roleslist = rolelist;
                }
                CustomMethods.ValidateRoles("Role");
                return View(objRoleModal);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult Create()
        {
            RoleModal model = new RoleModal();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RoleModal model, FormCollection Pages)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //model.CreatedBy = Convert.ToInt32(Session["UserId"]);
                    int res = new RolesBLL { }.AddEditRole(model);
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
                RoleModal model = objRolesBLL.GetRoleById(id);
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
                return View(new RoleModal());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult Edit(RoleModal model, FormCollection Pages)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // model.UpdatedBy = Convert.ToInt32(Session["UserId"]);
                    int res = new RolesBLL { }.AddEditRole(model);
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
            bool changestatus = new RolesBLL { }.ChangeStatus(id);
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
                RoleModal model = new RolesBLL { }.GetRoleById(id);
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
