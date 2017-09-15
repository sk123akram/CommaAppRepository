﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommaApp.DAL;
using CommaApp.CommonUtility;
using CommaApp.BLL;

namespace CommaApp.DAL
{
   public class RolesBLL
    {
        RolesDAL objroledal = new RolesDAL();

        public List<RoleModal> GetAllRoles()
        {
            try
            {
                return objroledal.GetAllRoles();
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
                return objroledal.GetAllRoles(skip, take);
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

        public int AddEditRole(RoleModal objmodel)
        {
            try
            {
                return objroledal.AddEditRole(objmodel);
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
                return objroledal.GetRoleById(id);
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
                return objroledal.GetRoleManagement(pageid, roleid);
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
                return objroledal.ChangeStatus(id);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
