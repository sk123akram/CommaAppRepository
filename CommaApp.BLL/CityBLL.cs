using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommaApp.CommonUtility;
using CommaApp.DAL;

namespace CommaApp.BLL
{
   public class CityBLL
    {
        CityDAL objcitydal = new CityDAL();

        public List<CityModel> GetAllCities()
        {
            try
            {
                return objcitydal.GetAllCities();
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
                return objcitydal.GetAllCities(skip, take, cid);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<CityModel> GetAllCities(int skip, int take)
        {
            try
            {
                return objcitydal.GetAllCities(skip, take);
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
                return objcitydal.AddEditCity(objmodel);
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public CityModel GetSubCityById(int id)
        {
            try
            {
                return objcitydal.GetSubCityById(id);
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
                return objcitydal.GetCityByStateId(id, str);
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
                return objcitydal.GetPageCount();
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
                return objcitydal.ChangeStatus(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CityModel> GetCityByParent(int id)
        {
            try
            {
                return objcitydal.GetCityByParent(id);
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
                return objcitydal.GetParentCities();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}


