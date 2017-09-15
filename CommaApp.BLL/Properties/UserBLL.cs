using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommaApp.DAL;
using CommaApp.CommonUtility;

namespace CommaApp.BLL
{
  public  class UserBLL
    {
      UserDAL objdal = new UserDAL();


      public List<UserModel> GetAllUsers()
      {
          try
          {
              return objdal.GetAllUsers();
          }
          catch (Exception)
          {
              return null;
              throw;
          }
      }

      public UserModel GetUserById(int id)
      {
          try
          {
              return objdal.GetUserById(id);
          }
          catch (Exception)
          {

              throw;
          }
      }

      //public UserModel GetUserDetailByPhone(string Phone)
      //{
      //    try
      //    {
      //        return objdal.GetUserDetailByPhone(Phone);
      //    }
      //    catch (Exception)
      //    {

      //        throw;
      //    }
      //}

      public int CheckEmail(string emailid)
      {
          try
          {
              return objdal.CheckEmail(emailid);
          }
          catch (Exception)
          {

              throw;
          }
      }

      //public int CheckPhone(string Phone)
      //{
      //    try
      //    {
      //        return objdal.CheckPhone(Phone);
      //    }
      //    catch (Exception)
      //    {

      //        throw;
      //    }
      //}

      //public int Checkusernamepassword(string username, string password)
      //{
      //    try
      //    {
      //        return objdal.Checkusernamepassword(username, password);
      //    }
      //    catch (Exception)
      //    {

      //        throw;
      //    }
      //}

      public bool CheckPassword(string Password)
      {
          try
          {
              return objdal.CheckPassword(Password);
          }
          catch (Exception)
          {

              return false;
              throw;
          }
      }

      public UserModel UserLogin(UserModel objmodel)
      {
          try
          {
              return objdal.UserLogin(objmodel);
          }
          catch (Exception)
          {
              return null;
              throw;
          }
      }

      //public UserModel GetCustomerDetailsByCredentials(string UserName, string password)
      //{
      //    try
      //    {
      //        return objdal.GetCustomerDetailsByCredentials(UserName, password);
      //    }
      //    catch (Exception)
      //    {
      //        return null;
      //    }
      //}

      public int AddUpdateUser(UserModel objmodel)
      {
          try
          {
              return objdal.AddUpdateUser(objmodel);
          }
          catch (Exception)
          {
              return 0;
              throw;
          }
      }

      public List<UserModel> GetAllUsers(int skip, int take)
      {
          try
          {
              return objdal.GetAllUsers(skip, take);
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

      public int ChangePassword(UserModel objModel)
      {
          try
          {
              return objdal.ChangePassword(objModel);
          }
          catch (Exception)
          {
              return 0;
              throw;
          }
      }

    }
}

