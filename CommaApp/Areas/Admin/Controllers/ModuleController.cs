using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommaApp.DAL;
using CommaApp.CommonUtility;
using CommaApp.BLL;
using CommaApp.Filters;


namespace CommaApp.Areas.Admin.Controllers
{
    public class ModuleController : Controller
    {

        // GET: /Admin/Module/
        ModuleBLL moduleBLL = new ModuleBLL();
        //
        public ActionResult Index(int pid = 0, int cid = 0)
        {
            try
            {
                int take;
                int skip;
                take = 10;
                skip = take * pid;
                ModulesModel ModuleModel = new ModulesModel();
                ModuleModel.PageID = pid;
                ModuleModel.Current = pid + 1;

                var modulelist = new ModuleBLL { }.GetAllModules(skip, take);
                if (modulelist != null)
                {
                    double count = Convert.ToDouble(new ModuleBLL { }.GetPageCount());
                    var res = count / take;
                    ModuleModel.Pagecount = (int)Math.Ceiling(res);
                    ModuleModel.ModuleList = modulelist;
                }
                CustomMethods.ValidateRoles("Module");
                return View(ModuleModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult Paging(int? Rec, int pid = 0, int cid = 0)
        {
            try
            {
                int take;
                int skip;
                Session["Records"] = (int)Rec;
                ViewBag.count = (int)Rec;
                if (Rec == null)
                {
                    take = (int)Session["Records"];
                }
                take = (int)Session["Records"];
                skip = take * pid;
                ModulesModel ModuleModel = new ModulesModel();
                ModuleModel.PageID = pid;
                ModuleModel.Current = pid + 1;

                var modulelist = new ModuleBLL { }.GetAllModules(skip, take);
                if (modulelist != null)
                {
                    double count = Convert.ToDouble(new ModuleBLL { }.GetPageCount());
                    var res = count / take;
                    ModuleModel.Pagecount = (int)Math.Ceiling(res);
                    ModuleModel.ModuleList = modulelist;
                }
                CustomMethods.ValidateRoles("Module");
                return View("Index", ModuleModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //
        // GET: /Admin/Module/Create

        public ActionResult Create()
        {
            return View(new ModulesModel());
        }

        //
        // POST: /Admin/Module/Create

        [HttpPost]
        public ActionResult Create(ModulesModel objModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objModel.CreatedBy = Convert.ToInt32(Session["UserId"]);
                    int res = moduleBLL.AddEditModule(objModel);

                    if (res != 0)
                    {
                        Session["Success"] = "Successfully Added The Record";
                        return RedirectToAction("Index");
                    }
                }

                catch (Exception e)
                {
                    throw e;
                }
            }
            Session["Error"] = "An Error has occured";
            return View(objModel);
        }

        //
        //GET: /Admin/Module/Edit/id

        public ActionResult Edit(int id, int pid = 0)
        {
            try
            {
                ModulesModel module = moduleBLL.GetModuleById(id);
                int take = 10;
                int skip = take * pid;
                module.PageID = pid;
                module.Current = pid + 1;
                ViewBag.c = module.PageID;
                if (module != null)
                {
                    return View(module);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            Session["Error"] = "Record does not exist";
            return View(new ModulesModel());
        }

        //
        //POST: /Admin/Module/Edit/id

        [HttpPost]
        public ActionResult Edit(ModulesModel objModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objModel.UpdatedBy = Convert.ToInt32(Session["UserId"]);
                    int res = moduleBLL.AddEditModule(objModel);

                    if (res != 0)
                    {
                        Session["Success"] = "Successfully updated";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            Session["Error"] = "An Error has occured";
            return View(objModel);
        }

        //
        //GET: /Admin/Module/Detaiil/Id

        public ActionResult Details(int Id, int pid = 0)
        {
            try
            {
                ModulesModel module = moduleBLL.GetModuleById(Id);
                int take = 10;
                int skip = take * pid;
                module.PageID = pid;
                module.Current = pid + 1;
                ViewBag.c = module.PageID;
                return View(module);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //
        //GET: /Admin/Module/ActiveInactive/Id

        public JsonResult ChangeStatusModule(int id)
        {
            bool result = false;
            bool ChangeStatus = moduleBLL.ActiveInactive(id);
            if (ChangeStatus)
            {
                result = true;
            }
            return Json(result);
        }

    }
}
