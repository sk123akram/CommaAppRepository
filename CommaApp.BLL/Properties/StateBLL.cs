using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommaApp.DAL;
using CommaApp.CommonUtility;

namespace CommaApp.BLL
{
  public  class StateBLL
    {

        StateDAL objdal = new StateDAL();

        public List<StateModel> GetAllState()
        {
            try
            {
                return objdal.GetAllState();
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
                return objdal.GetAllState(skip, take, cid);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<StateModel> GetAllState(int skip, int take)
        {
            try
            {
                return objdal.GetAllState(skip, take);
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
        //        return objdal.GetStateByCountryId(id);
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
                return objdal.AddEditState(objmodel);
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public StateModel GetSubStateById(int id)
        {
            try
            {
                return objdal.GetSubStateById(id);
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
                return objdal.GetPageCount();
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
                return objdal.ChangeStatus(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<StateModel> GetStateByParent(int id)
        {
            try
            {
                return objdal.GetStateByParent(id);
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
                return objdal.GetParentState();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}

