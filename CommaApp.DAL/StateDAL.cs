using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommaApp.CommonUtility;

namespace CommaApp.DAL
{
   public class StateDAL
    {
       CommaAppEntities objdb = new CommaAppEntities();


       public List<StateModel> GetAllState()
       {
           try
           {
               return objdb.States.Where(x => x.IsActive == true).Select(x => new StateModel
               {
                   StateId = x.StateID,
                   StateName = x.StateName,
                   CountryId = x.CountryId,
                   CountryName = x.Country.CountryName,
                  // CreatedBy = x.CreatedBy,
                   CreatedDate = x.CreatedDate,
                   IsActive = x.IsActive,
               }).OrderBy(x => x.StateName).ToList();
           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }

       public List<StateModel> GetAllState(int skip, int take, int cid)
       {
           try
           {
               return objdb.States.Where(x => x.CountryId != null && x.StateID == cid && x.IsActive == true).Select(x => new StateModel
               {
                   StateId = x.StateID,
                   StateName = x.StateName,
                   CountryId = x.CountryId,
                   CreatedDate = x.CreatedDate,
                   //CreatedBy = x.CreatedBy,
                  // UpdatedBy = x.UpdatedBy,
                   IsActive = x.IsActive,
               }).OrderByDescending(x => x.StateId == cid).Skip(skip).Take(take).ToList();
           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }

       public List<StateModel> GetAllState(int skip, int take)
       {
           try
           {
               return objdb.States.Where(x => x.CountryId != null).Select(x => new StateModel
               {
                   StateId = x.StateID,
                   StateName = x.StateName,
                   CountryId = x.CountryId,
                   CountryName = x.Country.CountryName,
                   CreatedDate = x.CreatedDate,
                  // CreatedBy = x.CreatedBy,
                  // UpdatedBy = x.UpdatedBy,
                   IsActive = x.IsActive,
                  
               }).OrderByDescending(x => x.StateId).Skip(skip).Take(take).ToList();
           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }

       //public Array GetStateByCountryId(int id)
       //{
       //    try
       //    {
       //        return objdb.States.Where(x => x.CountryId == id && x.IsActive == true).ToList().Select(x => new SelectListItem
       //        {
       //            Value = x.StateId.ToString(),
       //            Text = x.StateName

       //        }).ToArray();
       //    }
       //    catch (Exception)
       //    {
       //        return null;
       //        throw;
       //    }
       //}



       //public Array GetStateByCityId(int id)
       //{
       //    try
       //    {
       //        return objdb.Cities.Where(x => x.StateId == id && x.IsActive == true).ToList().Select(x => new SelectListItem
       //        {
       //            Value = x.CityId.ToString(),
       //            Text = x.CityName

       //        }).ToArray();
       //    }
       //    catch (Exception)
       //    {
       //        return null;
       //        throw;
       //    }
       //}
       public int AddEditState(StateModel objmodel)
       {

           try
           {

               if (objmodel.StateId == 0)
               {
                   State objsub = new State
                   {
                       StateName = objmodel.StateName,
                       CountryId = objmodel.CountryId,
                       CreatedDate = DateTime.Now,
                       //CreatedBy = objmodel.CreatedBy,
                       IsActive = objmodel.IsActive
                   };
                   objdb.States.Add(objsub);
                   objdb.SaveChanges();
                   return objsub.StateID;
               }
               else
               {
                   var objsubc = objdb.States.Find(objmodel.StateId);
                   objsubc.StateName = objmodel.StateName;
                   objsubc.CountryId = objmodel.CountryId;
                   objsubc.UpdatedDate = DateTime.Now;
                  // objsubc.UpdatedBy = objmodel.UpdatedBy;
                   objsubc.IsActive = objmodel.IsActive;
                   objdb.SaveChanges();
                   return objmodel.StateId;
               }
           }
           catch (Exception)
           {
               return 0;
               throw;
           }
       }


       public int GetPageCount()
       {
           try
           {
               return objdb.States.Where(x => x.StateName != null)
                           .Select(x => x.StateID).Count();
           }
           catch (Exception)
           {
               return 0;
               throw;
           }
       }

       public List<StateModel> GetStateByParent(int id)
       {
           try
           {
               return objdb.States.Where(x => x.StateID == id).Select(x => new StateModel
               {
                   StateId = x.StateID,
                   StateName = x.StateName,
               }).ToList();
           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }

       public List<StateModel> GetParentState()
       {
           try
           {
               return objdb.States.Where(x => x.IsActive == true).Select(x => new StateModel
               {
                   StateId = x.StateID,
                   StateName = x.StateName,
                   CountryId = x.CountryId,
                   CreatedDate = x.CreatedDate,
                   //CreatedBy = x.CreatedBy,
                   //UpdatedBy = x.UpdatedBy,
                   IsActive = x.IsActive
               }).ToList();
           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }

       public StateModel GetSubStateById(int id)
       {
           try
           {
               return objdb.States.Where(x => x.StateID == id).Select(x => new StateModel
               {
                   StateId = x.StateID,
                   StateName = x.StateName,
                   CountryName = x.Country.CountryName,
                   CountryId = x.CountryId,
                   IsActive = x.IsActive
               }).SingleOrDefault();
           }
           catch (Exception)
           {
               return null;
               throw;
           }
       }

       public bool ChangeStatus(int id)
       {
           try
           {
               var obj = objdb.States.Find(id);
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
