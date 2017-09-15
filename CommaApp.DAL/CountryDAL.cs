using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommaApp.CommonUtility;

namespace CommaApp.DAL
{
  public  class CountryDAL
    {
      CommaAppEntities objdb = new CommaAppEntities();

      public List<CountryModel> GetAllCountry()
      {
          try
          {
              return objdb.Countries.Where(x => x.IsActive == true).Select(x => new CountryModel
              {
                  CountryId = x.CountryId,
                  CountryName = x.CountryName,
                  CountryCode = x.CountryCode,
                  CreatedDate = x.CreatedDate,
                  UpdatedDate = x.UpdatedDate,
                  IsActive = x.IsActive,
              }).ToList();
          }
          catch (Exception)
          {
              return null;
              throw;
          }
      }

      public List<CountryModel> GetAllCountry(int skip, int take, int cid)
      {
          try
          {
              return objdb.Countries.Where(x => x.CountryId == cid).Select(x => new CountryModel
              {
                  CountryId = x.CountryId,
                  CountryName = x.CountryName,
                  CountryCode = x.CountryCode,
                  CreatedDate = x.CreatedDate,
                  UpdatedDate = x.UpdatedDate,
                  IsActive = x.IsActive,
              }).OrderByDescending(x => x.CountryId == cid).Skip(skip).Take(take).ToList();
          }
          catch (Exception)
          {
              return null;
              throw;
          }
      }

      public List<CountryModel> GetAllCountries(int skip, int take)
      {
          try
          {
              return objdb.Countries.Where(x => x.CountryId != null).Select(x => new CountryModel
              {
                  CountryId = x.CountryId,
                  CountryName = x.CountryName,
                  CreatedDate = x.CreatedDate,
                  UpdatedDate = x.UpdatedDate,
                  CountryCode = x.CountryCode,
                  IsActive = x.IsActive,
              }).OrderBy(x => x.CountryId).Skip(skip).Take(take).ToList();
          }
          catch (Exception)
          {
              return null;
              throw;
          }
      }

      public int AddEditCountry(CountryModel objmodel)
      {
          try
          {

              if (objmodel.CountryId == 0)
              {
                  Country objcountry = new Country
                  {
                      CountryName = objmodel.CountryName,
                      CountryCode = objmodel.CountryCode,
                      CreatedDate = DateTime.Now,
                     // CreatedBy = objmodel.CreatedBy,
                      IsActive = objmodel.IsActive
                  };
                  objdb.Countries.Add(objcountry);
                  objdb.SaveChanges();
                  return objcountry.CountryId;
              }
              else
              {
                  var objcountry = objdb.Countries.Find(objmodel.CountryId);
                  objcountry.CountryName = objmodel.CountryName;
                  objcountry.CountryCode = objmodel.CountryCode;
                  objcountry.CountryId = objmodel.CountryId;
                  objcountry.IsActive = objmodel.IsActive;
                  objcountry.UpdatedDate = DateTime.Now;
                  objcountry.CountryCode = objmodel.CountryCode;
                  //objcountry.UpdatedBy = objmodel.UpdatedBy;
                  objdb.SaveChanges();
                  return objmodel.CountryId;
              }
          }
          catch (Exception)
          {
              return 0;
              throw;
          }
      }

      public CountryModel GetCountryById(int id)
      {
          try
          {
              return objdb.Countries.Where(x => x.CountryId == id).Select(x => new CountryModel
              {
                  CountryId = x.CountryId,
                  CountryName = x.CountryName,
                  CountryCode = x.CountryCode,
                 // CreatedBy = x.CreatedBy,
                  IsActive = x.IsActive,
              }).SingleOrDefault();
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
              return objdb.Countries.Where(x => x.CountryId != null)
                          .Select(x => x.CountryId).Count();
          }
          catch (Exception)
          {
              return 0;
              throw;
          }
      }

      public List<CountryModel> GetCountryByParent(int id)
      {
          try
          {
              return objdb.Countries.Where(x => x.CountryId == id).Select(x => new CountryModel
              {
                  CountryId = x.CountryId,
                  CountryName = x.CountryName,
                  CountryCode = x.CountryCode,
              }).ToList();
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
              var obj = objdb.Countries.Find(id);
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