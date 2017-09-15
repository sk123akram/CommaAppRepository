using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommaApp.CommonUtility;
using CommaApp.DAL;

namespace CommaApp.BLL
{
    public class ModuleBLL
    {
        ModuleDAL moduleDAL = new ModuleDAL();

        public List<ModulesModel> GetAllModules(int skip, int take)
        {
            try
            {
                return moduleDAL.GetAllModules(skip, take);
            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }

        public List<ModulesModel> GetAllModules()
        {
            try
            {
                return moduleDAL.GetAllModules();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public int AddEditModule(ModulesModel objModel)
        {
            try
            {
                return moduleDAL.AddEditModule(objModel);
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public ModulesModel GetModuleById(int id)
        {
            try
            {
                return moduleDAL.GetModuleById(id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool CheckDuplicate(string moduleName)
        {
            try
            {
                return moduleDAL.CheckDuplicate(moduleName);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public int GetPageCount()
        {
            try
            {
                return moduleDAL.GetPageCount();
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public bool ActiveInactive(int id)
        {
            try
            {
                return moduleDAL.ActiveInactive(id);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
