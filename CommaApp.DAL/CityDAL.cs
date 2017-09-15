using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommaApp.CommonUtility;


namespace CommaApp.DAL
{

    public class CityDAL
    {
        CommaAppEntities objdb = new CommaAppEntities();

        public List<CityModel> GetAllCities()
        {
            try
            {
                return objdb.Cities.Where(x => x.IsActive == true).Select(x => new CityModel
                {
                    CityId = x.CityId,
                    CityName = x.CityName,
                    StateId = x.StateId,
                    StateName = x.State.StateName,
                   // CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    IsActive = x.IsActive,
                }).ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<CityModel> GetAllCities(int skip, int take, int cid)
        {
            try
            {
                return objdb.Cities.Select(x => new CityModel
                {
                    CityId = x.CityId,
                    CityName = x.CityName,
                    CreatedDate = x.CreatedDate,
                    StateId = x.StateId,
                   // CreatedBy = x.CreatedBy,
                    //UpdatedBy = x.UpdatedBy,
                    IsActive = x.IsActive,
                }).OrderByDescending(x => x.CityId == cid).Skip(skip).Take(take).ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<CityModel> GetAllCities(int skip, int take)
        {
            try
            {
                return objdb.Cities.Select(x => new CityModel
                {
                    CityId = x.CityId,
                    CityName = x.CityName,
                    StateId = x.StateId,
                    StateName = x.State.StateName,
                    CreatedDate = x.CreatedDate,
                   // CreatedBy = x.CreatedBy,
                    UpdatedDate = x.UpdatedDate,
                    IsActive = x.IsActive,
                }).OrderByDescending(x => x.CityId).Skip(skip).Take(take).ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }



        public int AddEditCity(CityModel objmodel)
        {

            try
            {

                if (objmodel.CityId == 0)
                {
                    City objsub = new City
                    {
                        CityName = objmodel.CityName,

                        StateId = objmodel.StateId,
                        CreatedDate = DateTime.Now,
                      //  CreatedBy = objmodel.CreatedBy,
                        IsActive = objmodel.IsActive
                    };
                    objdb.Cities.Add(objsub);
                    objdb.SaveChanges();
                    return objsub.CityId;
                }
                else
                {
                    var objsubc = objdb.Cities.Find(objmodel.CityId);
                    objsubc.CityName = objmodel.CityName;
                    objsubc.UpdatedDate = DateTime.Now;
                   // objsubc.UpdatedBy = objmodel.UpdatedBy;
                    objsubc.StateId = objmodel.StateId;
                    objsubc.IsActive = objmodel.IsActive;
                    objdb.SaveChanges();
                    return objmodel.CityId;
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
                return objdb.Cities.Where(x => x.CityName != null && x.IsActive == true)
                            .Select(x => x.CityId).Count();
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public List<CityModel> GetCityByParent(int id)
        {
            try
            {
                return objdb.Cities.Where(x => x.CityId == id).Select(x => new CityModel
                {
                    CityId = x.CityId,
                    CityName = x.CityName,
                }).ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<CityModel> GetParentCities()
        {
            try
            {
                return objdb.Cities.Where(x => x.IsActive == true).Select(x => new CityModel
                {
                    CityId = x.CityId,
                    CityName = x.CityName,
                    CreatedDate = x.CreatedDate,
                   // CreatedBy = x.CreatedBy,
                    UpdatedDate = x.UpdatedDate,
                    IsActive = x.IsActive
                }).ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public CityModel GetSubCityById(int id)
        {
            try
            {
                return objdb.Cities.Where(x => x.CityId == id).Select(x => new CityModel
                {
                    CityId = x.CityId,
                    CityName = x.CityName,
                    StateId = x.StateId,
                    StateName = x.State.StateName,
                    IsActive = x.IsActive
                }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }


        public List<CityModel> GetCityByStateId(int id, string str)
        {
            try
            {
                if (str != null)
                {
                    return objdb.Cities.Where(x => x.StateId == id && x.CityName.StartsWith(str)).Select(x => new CityModel
                    {
                        CityId = x.CityId,
                        CityName = x.CityName,
                        StateId = x.StateId,
                        StateName = x.State.StateName,
                        IsActive = x.IsActive
                    }).OrderBy(x => x.CityName).ToList();
                }
                else
                {
                    return objdb.Cities.Where(x => x.StateId == id).Select(x => new CityModel
                    {
                        CityId = x.CityId,
                        CityName = x.CityName,
                        StateId = x.StateId,
                        StateName = x.State.StateName,
                        IsActive = x.IsActive
                    }).OrderBy(x => x.CityName).ToList();
                }

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
                var obj = objdb.Cities.Find(id);
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
