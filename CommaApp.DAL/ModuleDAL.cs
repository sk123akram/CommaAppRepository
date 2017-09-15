using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommaApp.CommonUtility;
using CommaApp.DAL;


namespace CommaApp.DAL
{
    public class ModuleDAL
    {
        CommaAppEntities objDb = new CommaAppEntities();

        public List<ModulesModel> GetAllModules(int skip, int take)
        {
            try
            {
                List<ModulesModel> modules = new List<ModulesModel>();

                modules = objDb.Modules.Select(x => new ModulesModel
                {
                    ModuleId = x.ModuleId,
                    ModuleName = x.ModuleName,
                    IsActive = x.IsActive,
                    CreatedDate = x.CreatedDate,
                    // CreatedBy = x.CreatedBy,
                    UpdatedDate = x.UpdatedDate,
                    //  UpdatedBy = x.UpdatedBy
                }).OrderBy(x => x.ModuleId).Skip(skip).Take(take).ToList();

                return modules;

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
                return objDb.Modules.Where(x => x.IsActive == true).Select(x => new ModulesModel
                {
                    ModuleId = x.ModuleId,
                    ModuleName = x.ModuleName,
                    CreatedDate = x.CreatedDate,
                    // CreatedBy = x.CreatedBy,
                    UpdatedDate = x.UpdatedDate,
                    // UpdatedBy = x.UpdatedBy,
                    IsActive = x.IsActive
                }).ToList();
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
                if (objModel.ModuleId == 0)
                {
                    Module objModule = new Module
                    {
                        ModuleName = objModel.ModuleName,
                        CreatedDate = DateTime.Now,
                        IsActive = objModel.IsActive
                    };
                    objDb.Modules.Add(objModule);
                    objDb.SaveChanges();
                    return objModule.ModuleId;
                }
                else
                {
                    var module = objDb.Modules.Find(objModel.ModuleId);
                    module.ModuleName = objModel.ModuleName;
                    module.IsActive = objModel.IsActive;
                    module.UpdatedDate = DateTime.Now;
                    //module.UpdatedBy = objModel.UpdatedBy;
                    objDb.SaveChanges();
                    return module.ModuleId;
                }
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
                return objDb.Modules.Where(x => x.ModuleId == id).Select(x => new ModulesModel
                {
                    ModuleId = x.ModuleId,
                    ModuleName = x.ModuleName,
                    CreatedDate = x.CreatedDate,
                    //CreatedBy = x.CreatedBy,
                    UpdatedDate = x.UpdatedDate,
                    //UpdatedBy = x.UpdatedBy,
                    IsActive = x.IsActive
                }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool CheckDuplicate(string ModuleName)
        {
            bool result = false;
            try
            {
                ModulesModel modulesModel = objDb.Modules.Where(x => x.ModuleName == ModuleName.Trim()).Select(x => new ModulesModel
                {
                    ModuleId = x.ModuleId,
                    ModuleName = x.ModuleName,
                    IsActive = x.IsActive
                }).SingleOrDefault();
                if (modulesModel != null)
                {
                    result = true;
                }
                return result;
            }
            catch (Exception)
            {
                return result;
                throw;
            }
        }

        public int GetPageCount()
        {
            try
            {
                return objDb.Modules.Where(x => x.ModuleName != null).
                    Select(x => x.ModuleId).Count();
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
                var obj = objDb.Modules.Find(id);
                if (obj != null && obj.IsActive == true)
                {
                    obj.IsActive = false;
                    objDb.SaveChanges();
                    return false;
                }
                else if (obj != null)
                {
                    obj.IsActive = true;
                    objDb.SaveChanges();
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
