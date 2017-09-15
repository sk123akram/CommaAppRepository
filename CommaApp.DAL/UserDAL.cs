using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommaApp.CommonUtility;
using System.Text.RegularExpressions;

namespace CommaApp.DAL
{

    public class UserDAL
    {
        CommaAppEntities objdb = new CommaAppEntities();

        public UserModel GetUserById(int id)
        {
            try
            {
                return objdb.Users.Where(x => x.UserId == id).Select(x => new UserModel
                {
                    UserId = x.UserId,
                    UserName = x.UserName,
                    Password = x.Password,
                    UserTypeId = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    IsActive = x.IsActive,
                    //UserTypeName = x.UserType.UserTypeName,
                }).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }



        //public UserModel GetUserDetailByPhone(string Phone)
        //{
        //    try
        //    {
        //        return objdb.Users.Where(x => x.Phone == Phone).Select(x => new UserModel
        //        {
        //            UserId = x.UserId,
        //            UserName = x.UserName,
        //            UserTypeId = x.UserId,
        //            FirstName = x.FirstName,
        //            LastName = x.LastName,
        //            IsActive = x.IsActive,
        //            Phone=x.Phone,
        //            UserTypeName = x.UserType.UserTypeName,
        //        }).FirstOrDefault();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //        throw;
        //    }

        //}

        public int CheckEmail(string email)
        {
            int res = 0;
            try
            {
                res = objdb.Users.Where(x => x.UserName == email).Count();
                return res;
            }
            catch (Exception)
            {
                return res = 2;
                //throw;
            }
        }

        //public int CheckPhone(string Phone)
        //{
        //    int res = 0;
        //    try
        //    {
        //        res = objdb.Users.Where(x => x.Phone == Phone).Count();
        //        return res;
        //    }
        //    catch (Exception)
        //    {
        //        return res = 2;
        //        //throw;
        //    }
        //}





        //public int Checkusernamepassword(string username, string password )
        //{
        //    int res = 0;
        //    try
        //    {
        //        string MatchPhoneNumberPattern = "^\\(?([0-9]{3})\\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        //        UserModel userModel = new UserModel();
        //        if (Regex.IsMatch(username, MatchPhoneNumberPattern))
        //        {
        //            userModel = objdb.Users.Where(x => x.Phone == username && x.Password == password).Select(x => new UserModel
        //            {
        //                UserId = x.UserId,
        //                FirstName = x.FirstName,

        //                LastName = x.LastName
        //            }).FirstOrDefault();
        //        }

        //        else
        //        {
        //            userModel = objdb.Users.Where(x => x.UserName == username && x.Password == password).Select(x => new UserModel
        //            {
        //                UserId = x.UserId,
        //                FirstName = x.FirstName,
        //                LastName = x.LastName
        //            }).FirstOrDefault();
        //        }

        //        return res;
        //    }
        //    catch (Exception)
        //    {
        //        return res = 2;
        //        //throw;
        //    }
        //}

        public UserModel UserLogin(UserModel objmodel)
        {
            try
            {
                return objdb.Users.Where(x => x.UserName == objmodel.UserName && x.Password == objmodel.Password)
                            .Select(x => new UserModel
                            {
                                UserId = x.UserId,
                                UserName = x.UserName,
                                Password = x.Password,
                                UserTypeId = x.UserTypeId
                            }).SingleOrDefault();
            }
            catch (Exception)
            {
                //return null;
                throw;
            }
        }



        public bool CheckPassword(string Password)
        {
            bool res = false;

            try
            {
                var obj = objdb.Users.Where(x => x.Password == Password).FirstOrDefault();

                if (obj != null)
                {
                    res = true;
                }


                return res;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        //public UserModel GetCustomerDetailsByCredentials(string UserName, string password)
        //{
        //    try
        //    {
        //        string MatchPhoneNumberPattern = "^\\(?([0-9]{3})\\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        //        UserModel userModel = new UserModel();
        //        if (Regex.IsMatch(UserName, MatchPhoneNumberPattern))
        //        {
        //            userModel = objdb.Users.Where(x => x.Phone == UserName && x.Password == password && x.UserTypeId == 11).Select(x => new UserModel
        //                                {
        //                                    UserId = x.UserId,
        //                                    FirstName = x.FirstName,

        //                                    LastName = x.LastName
        //                                }).FirstOrDefault();
        //        }

        //        else
        //        {
        //            userModel = objdb.Users.Where(x => x.UserName == UserName && x.Password == password && x.UserTypeId == 11).Select(x => new UserModel
        //                                    {
        //                                        UserId = x.UserId,
        //                                        FirstName = x.FirstName,
        //                                        LastName = x.LastName
        //                                    }).FirstOrDefault();
        //        }

        //        return userModel;

        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //        throw;
        //    }
        //}

        public int AddUpdateUser(UserModel objmodel)
        {
            try
            {
                if (objmodel.UserId != 0)
                {
                    var user = objdb.Users.Find(objmodel.UserId);
                    user.UserName = objmodel.UserName;
                    user.FirstName = objmodel.FirstName;
                    user.UserTypeId = objmodel.UserTypeId;
                    user.Password = objmodel.Password;
                    user.IsActive = objmodel.IsActive;
                    user.LastName = objmodel.LastName;
                    user.UpdatedDate = DateTime.Now;
                    objdb.SaveChanges();
                    return objmodel.UserId;
                }
                else
                {
                    User objuser = new User
                    {
                        UserName = objmodel.UserName,
                        FirstName = objmodel.FirstName,
                        Password = DataEncryption.Encrypt(objmodel.Password.Trim(), "passKey"),
                        UserTypeId = objmodel.UserTypeId,
                        IsActive = objmodel.IsActive,
                        CreatedDate = DateTime.Now,
                    };

                    objdb.Users.Add(objuser);
                    objdb.SaveChanges();
                    return objuser.UserId;
                }
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public List<UserModel> GetAllUsers()
        {
            try
            {
                return objdb.Users.Select(x => new UserModel
                {
                    UserId = x.UserId,
                    UserName = x.UserName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Password = x.Password,
                    UserTypeId = x.UserTypeId
                }).OrderByDescending(x => x.UserId).ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<UserModel> GetAllUsers(int skip, int take)
        {
            try
            {
                return objdb.Users.Select(x => new UserModel
                {
                    UserId = x.UserId,
                    UserName = x.UserName,
                    Password = x.Password,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserTypeId = x.UserTypeId,
                    IsActive = x.IsActive,
                }).OrderByDescending(x => x.UserId).Skip(skip).Take(take).ToList();
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
                return objdb.Users.Select(x => x.UserId).Count();
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public bool ChangeStatus(int id)
        {
            try
            {
                var obj = objdb.Users.Find(id);
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

        public int ChangePassword(UserModel objmodel)
        {
            try
            {

                User objuser = objdb.Users.Find(objmodel.UserId);
                {
                    objuser.UserId = objmodel.UserId;
                    objuser.Password = objmodel.Password;
                };
                objdb.SaveChanges();
                return objuser.UserId;

            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        #region Administrator

        public UserModel AdminLogin(UserModel objmodel)
        {
            try
            {
                return objdb.Administrators.Where(x => x.UserName == objmodel.UserName && x.Password == objmodel.Password)
                            .Select(x => new UserModel
                            {
                                AdminId = x.AdminID,
                                UserName = x.UserName,
                                Password = x.Password,
                                RoleId = x.RoleId
                            }).SingleOrDefault();
            }
            catch (Exception)
            {
                //return null;
                throw;
            }
        }

        #endregion

    }
}
