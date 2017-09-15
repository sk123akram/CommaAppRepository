using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommaApp.CommonUtility;
using CommaApp.DAL;

namespace CommaApp.BLL
{
    public class UserTypeBLL
    {
        UserTypeDAL objroledal = new UserTypeDAL();

        public List<UserTypeModel> GetAllUserTypes()
        {
            try
            {
                return objroledal.GetAllUserTypes();
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
                return objroledal.GetAllUserTypes(skip, take);
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
                return objroledal.GetPageCount();
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
                return objroledal.AddEditUserType(objmodel);
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
                return objroledal.GetUserTypeById(id);
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
                return objroledal.GetUserTypeManagement(pageid, roleid);
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
                return objroledal.ChangeStatusUserType(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RoleAssignmentModel> GetAllUserTypeAssignments()
        {
            try
            {
                return objroledal.GetAllUserTypeAssignments();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }


    }
}
