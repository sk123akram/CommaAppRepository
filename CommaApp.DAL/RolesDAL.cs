using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommaApp.CommonUtility;
using CommaApp.DAL;

namespace CommaApp.DAL
{
    public class RolesDAL
    {
        CommaAppEntities objdb = new CommaAppEntities();

        //CommaAppEntities

        public List<RoleModal> GetAllRoles()
        {
            try
            {
                return objdb.Roles.Where(x => x.IsActive == true).Select(x => new RoleModal
                {
                    RoleId = x.RoleId,
                    RoleName = x.RoleName,
                    IsActive = x.IsActive,
                }).ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }


        public List<RoleModal> GetAllRoles(int skip, int take)
        {
            try
            {
                return objdb.Roles.Select(x => new RoleModal
                {
                    RoleId = x.RoleId,
                    RoleName = x.RoleName,
                    IsActive = x.IsActive,
                }).OrderByDescending(x => x.RoleId).Skip(skip).Take(take).ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public int GetPageCount()
        {
            try
            {
                return objdb.Roles.Where(x => x.IsActive == true)
                            .Select(x => x.RoleId).Count();
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public int AddEditRole(RoleModal objmodel)
        {
            try
            {

                if (objmodel.RoleId != 0)
                {
                    var objrole = objdb.Roles.Find(objmodel.RoleId);
                    objrole.RoleName = objmodel.RoleName;
                    objrole.IsActive = true;
                    objdb.SaveChanges();

                    foreach (var item in objmodel.Rolemanages)
                    {
                        var obj = objdb.RoleAssignments.Where(x => x.RoleId == objrole.RoleId).SingleOrDefault();   //&& x.PageID == pageid
                        obj.IsAdd = item.IsAdd;
                        obj.IsEdit = item.IsEdit;
                        obj.IsDelete = item.IsDelete;
                        obj.IsEnable = item.IsEnable;
                        obj.IsView = item.IsView;
                        objdb.SaveChanges();
                    }

                    return objmodel.RoleId;
                }
                else
                {
                    Role objrole = new Role
                    {
                        IsActive = objmodel.IsActive,
                        RoleName = objmodel.RoleName,
                    };
                    objdb.Roles.Add(objrole);
                    objdb.SaveChanges();


                    foreach (var item in objmodel.Rolemanages)
                    {
                        RoleAssignment obj = new RoleAssignment
                        {
                            IsAdd = item.IsAdd,
                            IsEdit = item.IsEdit,
                            IsDelete = item.IsDelete,
                            IsView = item.IsView,
                            IsEnable = item.IsEnable,
                            RoleId = objrole.RoleId,

                        };

                        objdb.RoleAssignments.Add(obj);
                        objdb.SaveChanges();
                    }
                    return objrole.RoleId;

                }
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public RoleModal GetRoleById(int id)
        {
            try
            {
                var res = objdb.Roles.Where(x => x.RoleId == id).Select(x => new RoleModal
                {
                    RoleId = x.RoleId,
                    RoleName = x.RoleName,
                    IsActive = x.IsActive,
                }).SingleOrDefault();

                res.Rolemanages = objdb.RoleAssignments.Where(x => x.RoleId == id).Select(x => new RolemanagementModel
                {
                    RoleID = x.RoleId,
                    IsAdd = x.IsAdd,
                    IsEdit = x.IsEdit,
                    IsDelete = x.IsDelete,
                    IsView = x.IsView,
                    IsEnable = x.IsEnable
                }).ToList();
                return res;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public RolemanagementModel GetRoleManagement(int pageid, int roleid)
        {
            try
            {
                return objdb.RoleAssignments.Where(x => x.RoleId == roleid)
                    .Select(x => new RolemanagementModel
                    {
                        IsAdd = x.IsAdd,
                        IsEdit = x.IsEdit,
                        IsDelete = x.IsDelete,
                        IsView = x.IsView,
                        RoleID = x.RoleId,
                        IsEnable = x.IsEnable
                    }).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ChangeStatus(int id)
        {
            try
            {
                var obj = objdb.Roles.Find(id);
                if (obj != null && obj.IsActive == true)
                {
                    obj.IsActive = false;
                    objdb.SaveChanges();
                    return false;
                }
                else if (obj != null)
                {
                    obj.IsActive = true;
                    objdb.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
    }
}
