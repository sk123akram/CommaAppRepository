using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommaApp.CommonUtility;
using CommaApp.BLL;
using CommaApp.DAL;
using CommaApp.Filters;



namespace CommaApp.Areas.Admin.Controllers
{
    public class RoleAssignmentController : Controller
    {
        //
        // GET: /Admin/RoleAssignment/
        UserTypeBLL usertypebll = new UserTypeBLL();
        RolesBLL UserRolebll = new RolesBLL();
        ModuleBLL modulebll = new ModuleBLL();
        CommaAppEntities objdb = new CommaAppEntities();

        public ActionResult Index(int pid = 0, int cid = 0)
        {
            try
            {
                int take = 10;
                int skip = take * pid;
                var totalCount = UserRolebll.GetAllRoles().Count();
                RoleModal objRoleModal = new RoleModal();
                objRoleModal.PageID = pid;
                objRoleModal.Current = pid + 1;
                int roleid = Convert.ToInt32(Session["RoleId"]);
                int moduleid = Convert.ToInt32(Session["ModuleId"]);
                var selectRoles = UserRolebll.GetAllRoles();
                List<RoleModal> listObj = selectRoles.Select(x => new RoleModal
                {
                    RoleId = x.RoleId,
                    RoleName = x.RoleName,
                    PageID = pid,
                    Current = pid + 1,
                }).OrderBy(x => x.RoleId).Skip(skip).Take(take).ToList();
                if (listObj != null)
                {
                    double count = Convert.ToDouble(new UserTypeBLL { }.GetPageCount());
                    var res = count / take;
                    objRoleModal.Pagecount = (int)Math.Ceiling(res);
                }
                objRoleModal.Roleslist = listObj;
                CustomMethods.ValidateRoles("RoleAssignment");
                return View(objRoleModal);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult Edit(int id, int pid = 0)
        {
            try
            {
                var role = usertypebll.GetAllUserTypeAssignments();
                //var AllRoles = usertypebll.GetAllUserTypes();
                var AllRoles = UserRolebll.GetAllRoles();
                var AllModules = modulebll.GetAllModules();

                List<int> roAss = new List<int>();
                List<int> ModId = new List<int>();
                List<int> FinalModId = new List<int>();
                RoleAssignmentModel _userRoles = new RoleAssignmentModel();
                int take = 10;
                int skip = take * pid;
                _userRoles.PageID = pid;
                _userRoles.Current = pid + 1;
                ViewBag.c = _userRoles.PageID;
                List<RoleAssignmentModel> _Roles = objdb.RoleAssignments.Where(x => x.UserTypeId == id).Select(x => new RoleAssignmentModel
                {
                    RoleAssgnId = x.Id,
                    UserTypeId = x.UserTypeId,
                    RoleName = x.Role.RoleName,
                    ModuleName = x.Module.ModuleName,
                    ModuleId = x.ModuleId,
                    IsAdd = x.IsAdd,
                    IsEdit = x.IsEdit,
                    IsDelete = x.IsDelete,
                    IsView = x.IsView,
                    IsEnable = x.IsEnable,
                    IsActive = x.IsActive
                }).ToList();

                // selecting ModuleId from RoleAssignment table based on RoleId
                roAss = (from mi in role where mi.UserTypeId == id select mi.ModuleId).ToList();
                // Select All ModuleId from Module...
                ModId = (from mo in AllModules select mo.ModuleId).ToList();

                // RoleAssignment not containing Module 
                foreach (int str in ModId)
                {
                    if (!roAss.Contains(str))
                        FinalModId.Add(str);
                }

                List<RoleAssignmentModel> _allMod = new List<RoleAssignmentModel>();
                _allMod = AllModules.Select(x => new RoleAssignmentModel
                {
                    ModuleId = x.ModuleId,
                    ModuleName = x.ModuleName,
                    IsAdd = false,
                    IsEdit = false,
                    IsDelete = false,
                    IsView = false,
                    IsEnable = false,
                    IsActive = false,
                }).ToList();

                // Adding Role module list to  new Module which are not in list
                foreach (var item in _allMod)
                {
                    if (FinalModId.Contains(item.ModuleId))
                    {
                        _Roles.Add(item);
                    }
                }
                List<RoleModal> _roleModel = AllRoles.Select(x => new RoleModal
                {
                    RoleId = x.RoleId,
                    RoleName = x.RoleName,

                }).ToList();

                _userRoles.UserTypeId = id;
                _userRoles.ModuleList = _Roles;
                _userRoles.RolesModel = _roleModel;
                Session["ModList"] = _Roles;
                return View(_userRoles);
            }
            catch (Exception e)
            {
                //ViewBag.msg = "Refersh Page ";
                //return RedirectToAction("Index");
                throw e;
            }
        }


        public ActionResult Update(RoleAssignmentModel roleAssigmnetModel, List<string> addOptions, List<string> editOptions, List<string> delOptions, List<string> viewOptions, List<string> statusOptions, List<string> AllModuleId)
        {
            try
            {
                List<string> roAss = new List<string>();
                List<string> FinalModId = new List<string>();
                var assignments = objdb.RoleAssignments.Where(x => x.UserTypeId == roleAssigmnetModel.UserTypeId).Select(x => new RoleAssignmentModel
                {
                    RoleAssgnId = x.Id,
                    UserTypeId = x.UserTypeId,
                    UserTypeName = x.UserType.UserTypeName,
                    ModuleId = x.ModuleId,
                    ModuleName = x.Module.ModuleName,
                    IsAdd = x.IsAdd,
                    IsEdit = x.IsEdit,
                    IsDelete = x.IsDelete,
                    IsView = x.IsView,
                    IsEnable = x.IsEnable,
                    IsActive = x.IsActive
                }).ToList();

                // selecting ModuleId from RoleAssignment table based on RoleId
                roAss = (from mi in assignments select Convert.ToString(mi.ModuleId)).ToList();

                foreach (string str in AllModuleId)
                {
                    if (!roAss.Contains(str))
                        FinalModId.Add(str);
                }

                #region Update Role Assignments

                foreach (var item in assignments)
                {
                    RoleAssignment objRoleAssignmet = objdb.RoleAssignments.Find(item.RoleAssgnId);

                    if (objRoleAssignmet != null)
                    {
                        if (addOptions != null)
                        {
                            if (addOptions.Contains(item.ModuleId.ToString()))
                                objRoleAssignmet.IsAdd = true;
                            else
                                objRoleAssignmet.IsAdd = false;
                        }
                        else
                        {
                            objRoleAssignmet.IsAdd = false;
                        }

                        if (editOptions != null)
                        {
                            if (editOptions.Contains(item.ModuleId.ToString()))
                                objRoleAssignmet.IsEdit = true;
                            else
                                objRoleAssignmet.IsEdit = false;
                        }
                        else
                        {
                            objRoleAssignmet.IsEdit = false;
                        }

                        if (delOptions != null)
                        {
                            if (delOptions.Contains(item.ModuleId.ToString()))
                                objRoleAssignmet.IsDelete = true;
                            else
                                objRoleAssignmet.IsDelete = false;
                        }
                        else
                        {
                            objRoleAssignmet.IsDelete = false;
                        }

                        if (viewOptions != null)
                        {
                            if (viewOptions.Contains(item.ModuleId.ToString()))
                                objRoleAssignmet.IsView = true;
                            else
                                objRoleAssignmet.IsView = false;
                        }
                        else
                        {
                            objRoleAssignmet.IsView = false;
                        }

                        if (statusOptions != null)
                        {
                            if (statusOptions.Contains(item.ModuleId.ToString()))
                                objRoleAssignmet.IsActive = true;
                            else
                                objRoleAssignmet.IsActive = false;
                        }
                        else
                        {
                            objRoleAssignmet.IsActive = false;
                        }

                        objdb.RoleAssignments.Add(objRoleAssignmet);
                        //objRoleAssignmet.UpdatedDate = DateTime.Now;
                        // objRoleAssignmet.UpdatedBy = Convert.ToInt32(Session["UserId"]);
                        objdb.SaveChanges();
                    }
                }

                #endregion

                #region Insert RoleAssignment

                if (FinalModId.Count > 0)
                {
                    foreach (var item in FinalModId)
                    {
                        int mid = Convert.ToInt32(item);
                        RoleAssignment _role = new RoleAssignment();
                        _role.UserTypeId = roleAssigmnetModel.UserTypeId;
                        _role.ModuleId = mid;

                        var data = (from d in modulebll.GetAllModules() where d.ModuleId == mid select d).ToList();
                        if (data.Count > 0)
                        {
                            foreach (var val in data)
                            {
                                if (addOptions != null)
                                {
                                    if (addOptions.Contains(Convert.ToString(val.ModuleId)))
                                        _role.IsAdd = true;
                                    else _role.IsAdd = false;
                                }
                                else
                                {
                                    _role.IsAdd = false;
                                }

                                if (editOptions != null)
                                {
                                    if (editOptions.Contains(Convert.ToString(val.ModuleId)))
                                        _role.IsEdit = true;
                                    else _role.IsEdit = false;
                                }
                                else
                                {
                                    _role.IsEdit = false;
                                }

                                if (delOptions != null)
                                {
                                    if (delOptions.Contains(Convert.ToString(val.ModuleId)))
                                        _role.IsDelete = true;
                                    else _role.IsDelete = false;
                                }
                                else
                                {
                                    _role.IsDelete = false;
                                }

                                if (viewOptions != null)
                                {
                                    if (viewOptions.Contains(Convert.ToString(val.ModuleId)))
                                        _role.IsView = true;
                                    else _role.IsView = false;
                                }
                                else
                                {
                                    _role.IsView = false;
                                }

                                if (statusOptions != null)
                                {
                                    if (statusOptions.Contains(Convert.ToString(val.ModuleId)))
                                        _role.IsActive = true;
                                    else _role.IsActive = false;
                                }
                                else
                                {
                                    _role.IsActive = false;
                                }
                                //_role.CreatedBy = Convert.ToInt32(Session["UserId"]);
                                //_role.CreatedDate = DateTime.Now;
                                objdb.RoleAssignments.Add(_role);
                                objdb.SaveChanges();
                            }
                        }
                    }
                }
                #endregion

            }
            catch (Exception e)
            {
                throw e;
            }
            Session["Success"] = "Successfully updated";
            return RedirectToAction("Index", "RoleAssignment");
        }


    }
}
