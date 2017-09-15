using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommaApp.CommonUtility;
using CommaApp.DAL;

namespace CommaApp.DAL
{
    public class UserTypeDAL
    {
        CommaAppEntities objdb = new CommaAppEntities();

        public List<UserTypeModel> GetAllUserTypes()
        {
            try
            {
                return objdb.UserTypes.Where(x => x.IsActive == true).Select(x => new UserTypeModel
                {
                    UserTypeId = x.UserTypeId,
                    UserTypeName = x.UserTypeName,
                    CreatedDate = x.CreatedDate,
                    //CreatedBy = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    //UpdatedBy = x.UpdatedDate,
                    IsActive = x.IsActive,
                }).ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<UserTypeModel> GetAllUserTypes(int skip, int take)
        {
            try
            {
                return objdb.UserTypes.Select(x => new UserTypeModel
                {
                    UserTypeId = x.UserTypeId,
                    UserTypeName = x.UserTypeName,
                    CreatedDate = x.CreatedDate,
                   // CreatedBy = x.CreatedBy,
                    UpdatedDate = x.UpdatedDate,
                   // UpdatedBy = x.UpdatedBy,
                    IsActive = x.IsActive,
                }).OrderByDescending(x => x.UserTypeId).Skip(skip).Take(take).ToList();
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
                return objdb.UserTypes.Where(x => x.IsActive == true)
                            .Select(x => x.UserTypeId).Count();
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public int AddEditUserType(UserTypeModel objmodel)
        {
            try
            {

                if (objmodel.UserTypeId != 0)
                {
                    var objrole = objdb.UserTypes.Find(objmodel.UserTypeId);
                    objrole.UserTypeName = objmodel.UserTypeName;
                    objrole.UserTypeId = objmodel.UserTypeId;
                    //objrole.UpdatedBy = objmodel.UpdatedBy;
                    objrole.UpdatedDate = DateTime.Now;
                    objrole.IsActive = objmodel.IsActive;
                    objdb.SaveChanges();
                    return objmodel.UserTypeId;
                }
                else
                {
                    UserType objrole = new UserType
                    {
                        IsActive = objmodel.IsActive,
                        UserTypeName = objmodel.UserTypeName,
                       // CreatedBy = objmodel.CreatedBy,
                        CreatedDate = DateTime.Now,
                    };
                    objdb.UserTypes.Add(objrole);
                    objdb.SaveChanges();
                    return objrole.UserTypeId;

                }
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public UserTypeModel GetUserTypeById(int id)
        {
            try
            {
                var res = objdb.UserTypes.Where(x => x.UserTypeId == id).Select(x => new UserTypeModel
                {
                    UserTypeId = x.UserTypeId,
                    UserTypeName = x.UserTypeName,
                    IsActive = x.IsActive,
                }).SingleOrDefault();

                res.RoleAssignments = objdb.RoleAssignments.Where(x => x.UserTypeId == id).Select(x => new RoleAssignmentModel
                {
                    UserTypeId = x.UserTypeId,
                    IsAdd = x.IsAdd,
                    IsEdit = x.IsEdit,
                    IsDelete = x.IsDelete,
                    IsView = x.IsView,
                    
                    IsEnable=x.IsEnable,
                    ModuleId = x.ModuleId,
                    ModuleName = x.Module.ModuleName
                }).ToList();
                return res;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public RoleAssignmentModel GetUserTypeManagement(int pageid, int roleid)
        {
            try
            {
                return objdb.RoleAssignments.Where(x => x.RoleId == roleid && x.ModuleId == pageid)
                    .Select(x => new RoleAssignmentModel
                    {
                        Id=x.Id,
                        IsAdd = x.IsAdd,
                        IsEdit = x.IsEdit,
                        IsDelete = x.IsDelete,
                        IsView=x.IsView,
                        IsEnable=x.IsEnable,
                        RoleId = x.RoleId,
                        ModuleId = x.ModuleId,
                        IsActive = x.IsActive,
                    }).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ChangeStatusUserType(int id)
        {
            try
            {
                var obj = objdb.UserTypes.Find(id);
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

        public List<RoleAssignmentModel> GetAllUserTypeAssignments()
        {
            try
            {
                return objdb.RoleAssignments.Select(x => new RoleAssignmentModel
                {
                    IsAdd = x.IsAdd,
                    IsDelete = x.IsDelete,
                    IsEdit = x.IsEdit,
                    IsView=x.IsView,
                    IsEnable=x.IsEnable,
                    RoleId=x.RoleId,
                    UserTypeId = x.UserTypeId,
                    ModuleId = x.ModuleId,
                    IsActive = x.IsActive,
                }).ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

    }
}
