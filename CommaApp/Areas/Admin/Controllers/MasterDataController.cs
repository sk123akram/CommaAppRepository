using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommaApp.CommonUtility;
using CommaApp.DAL;
using CommaApp.BLL;
using System.Net.Mail;
using System.Net;
using System.Collections.Specialized;

namespace CommaApp.Areas.Admin.Controllers
{
    public class MasterDataController : Controller
    {

        CommaAppEntities objdb = new CommaAppEntities();

        #region Country
        public ActionResult Country(int pid = 0, int cid = 0)
        {
            int take = 10;
            int skip = take * pid;
            CountryModel model = new CountryModel();
            model.PageID = pid;
            model.Current = pid + 1;
            IEnumerable<CountryModel> Countries = new List<CountryModel>();
            //CustomMethods.ValidateRoles("Country");
            var countries = new CountryBLL { }.GetAllCountries(skip, take);
            if (cid != 0)
            {
                var sortedlist = new CountryBLL { }.GetAllCountry(skip, take, cid);
                double count = Convert.ToDouble(sortedlist.Count);
                var res = count / take;
                model.Pagecount = (int)Math.Ceiling(res);
                model.CountryList = sortedlist.Select(x => new CountryModel
                {
                    CountryId = x.CountryId,
                    CountryName = x.CountryName,
                    IsActive = Convert.ToBoolean(x.IsActive)
                }).ToList();
            }
            else
            {
                if (countries != null)
                {
                    double count = Convert.ToDouble(new CountryBLL { }.GetPageCount());
                    var res = count / take;
                    model.Pagecount = (int)Math.Ceiling(res);
                    model.CountryList = countries.Select(x => new CountryModel
                    {
                        CountryId = x.CountryId,
                        CountryName = x.CountryName,
                        CountryCode = x.CountryCode,
                        IsActive = Convert.ToBoolean(x.IsActive)
                    }).ToList();
                }
            }
            return View(model);
        }

        public ActionResult AddEditCountry(int id = 0, int pid = 0)
        {
            //CustomMethods.ValidateRoles("Country");
            if (!Convert.ToBoolean(Session["Add"]) && !Convert.ToBoolean(Session["Edit"]))
                return View("ErrorPage", "Error");
            CountryModel CountryModel = new CountryModel();
            int take = 10;
            int skip = take * pid;
            CountryModel.PageID = pid;
            CountryModel.Current = pid + 1;
            ViewBag.c = CountryModel.PageID;
            if (id != 0)
            {
                var objcountry = new CountryBLL { }.GetCountryById(id);
                if (objcountry != null)
                {
                    CountryModel.CountryId = objcountry.CountryId;
                    CountryModel.CountryName = objcountry.CountryName;
                    CountryModel.CountryCode = objcountry.CountryCode;
                    CountryModel.IsActive = Convert.ToBoolean(objcountry.IsActive);
                }
            }
            return View(CountryModel);
        }

        [HttpPost]
        public ActionResult AddEditCountry(CountryModel model)
        {
            int result = 0;
            CountryBLL countryBLL = new CountryBLL();

            if (model.CountryId == 0)
            {
                if (!Convert.ToBoolean(Session["Add"]))
                    return View("ErrorPage");
            }
            else
            {
                if (!Convert.ToBoolean(Session["Edit"]))
                    return View("ErrorPage");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CountryId == 0)
                    {
                        var checkDuplicate = objdb.Countries.Where(x => x.CountryName == model.CountryName).FirstOrDefault();
                        if (checkDuplicate == null)
                        {
                            int res = countryBLL.AddEditCountry(new CountryModel
                            {
                                CountryName = model.CountryName,
                                CountryCode = model.CountryCode,
                                IsActive = model.IsActive,
                                CreatedBy = Convert.ToInt32(Session["UserId"]),
                            });
                            if (res != 0)
                            {
                                Session["Success"] = "Successfully Added The Record";
                                return RedirectToAction("Country");
                            }
                        }

                        Session["Error"] = "Record Already Exists";
                        return RedirectToAction("AddEditCountry");
                    }
                    else
                    {
                        if (model.CountryId == 0)
                        {
                            Session["Error"] = "Record Already Exists";
                            return RedirectToAction("AddEditCountry");
                        }
                        else
                        {
                            model.UpdatedBy = Convert.ToInt32(Session["UserId"]);
                            result = countryBLL.AddEditCountry(model);

                            if (result != 0)
                            {
                                Session["Success"] = "Successfully Updated The Record";
                                return RedirectToAction("Country");
                            }
                        }
                    }

                }
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }
        }

        public ActionResult ViewCountry(int id = 0, int pid = 0)
        {
           // CustomMethods.ValidateRoles("Country");
            if (!Convert.ToBoolean(Session["Add"]) && !Convert.ToBoolean(Session["Edit"]))
                return View("ErrorPage", "Error");
            CountryModel country = new CountryModel();
            int take = 10;
            int skip = take * pid;
            country.PageID = pid;
            country.Current = pid + 1;
            ViewBag.c = country.PageID;
            if (id != 0)
            {
                var objcountry = new CountryBLL { }.GetCountryById(id);
                if (objcountry != null)
                {
                    country.CountryName = objcountry.CountryName;
                    country.CountryCode = objcountry.CountryCode;
                    country.CountryId = objcountry.CountryId == null ? 0 : Convert.ToInt32(objcountry.CountryId);
                    country.IsActive = Convert.ToBoolean(objcountry.IsActive);
                }
            }
            return View(country);
        }

        public JsonResult ChangeCountryStatus(int id)
        {
            bool Result = false;
            bool changestatus = new CountryBLL { }.ChangeStatus(id);
            if (changestatus)
            {
                Result = true;

            }
            return Json(Result);
        }


        #endregion


        #region state

        public ActionResult State(string SearchValue, string sortOrder, int pid = 0, int cid = 0)
        {

            int take = 10;
            int skip = take * pid;
            StateModel model = new StateModel();
            model.PageID = pid;
            model.Current = pid + 1;
            IEnumerable<StateModel> Courses = new List<StateModel>();
            //CustomMethods.ValidateRoles("State");
            var Citieslist = new StateBLL { }.GetAllState(skip, take);
            if (cid != 0)
            {
                var sortedlist = new StateBLL { }.GetAllState(skip, take, cid);
                double count = Convert.ToDouble(sortedlist.Count);
                var res = count / take;
                model.Pagecount = (int)Math.Ceiling(res);
                model.StateList = sortedlist.Select(x => new StateModel
                {
                    CountryId = x.CountryId,
                    CountryName = x.CountryName,
                    StateId = x.StateId,
                    StateName = x.StateName,
                    IsActive = Convert.ToBoolean(x.IsActive)
                }).ToList();

            }
            else
            {
                if (Citieslist != null)
                {
                    double count = Convert.ToDouble(new StateBLL { }.GetPageCount());
                    var res = count / take;
                    model.Pagecount = (int)Math.Ceiling(res);
                    model.StateList = Citieslist.Select(x => new StateModel
                    {
                        CountryId = x.CountryId,
                        CountryName = x.CountryName,
                        StateId = x.StateId,
                        StateName = x.StateName,
                        IsActive = Convert.ToBoolean(x.IsActive)
                    }).ToList();


                }
            }

            return View(model);
        }

        public ActionResult AddEditState(int id = 0, int pid = 0)
        {
            //CustomMethods.ValidateRoles("State");
            if (!Convert.ToBoolean(Session["Add"]) && !Convert.ToBoolean(Session["Edit"]))
                return View("ErrorPage", "Error");
            StateModel StateModel = new StateModel();
            int take = 10;
            int skip = take * pid;
            StateModel.PageID = pid;
            StateModel.Current = pid + 1;
            ViewBag.c = StateModel.PageID;
            if (id != 0)
            {
                var objstate = new StateBLL { }.GetSubStateById(id);
                if (objstate != null)
                {
                    StateModel.StateId = objstate.StateId;
                    StateModel.StateName = objstate.StateName;
                    StateModel.CountryId = objstate.CountryId;
                    StateModel.IsActive = Convert.ToBoolean(objstate.IsActive);
                }
            }
            //CustomMethods.BindCountryList(StateModel);
            return View(StateModel);
        }

        [HttpPost]
        public ActionResult AddEditState(StateModel model)
        {
            int result = 0;
            StateBLL StateBLL = new StateBLL();
            try
            {

                if (model.StateId == 0)
                {
                    if (!Convert.ToBoolean(Session["Add"]))
                        return View("ErrorPage");
                }
                else
                {
                    if (!Convert.ToBoolean(Session["Edit"]))
                        return View("ErrorPage");
                }
                if (ModelState.IsValid)
                {
                    if (model.StateId == 0)
                    {
                        var checkDuplicate = objdb.States.Where(x => x.StateName == model.StateName).FirstOrDefault();
                        if (checkDuplicate == null)
                        {
                            int res = new StateBLL { }.AddEditState(new StateModel
                            {
                                StateName = model.StateName,
                                CountryId = model.CountryId,
                                IsActive = model.IsActive,
                                CreatedBy = Convert.ToInt32(Session["UserId"]),
                            });
                            if (res != 0)
                            {
                                Session["Success"] = "Successfully Added The Record";
                                return RedirectToAction("State");
                            }
                        }
                        Session["Error"] = "Record Already Exists";
                        return RedirectToAction("AddEditState");
                    }


                    else
                    {
                        model.UpdatedBy = Convert.ToInt32(Session["UserId"]);
                        result = StateBLL.AddEditState(model);

                        if (result != 0)
                        {
                            Session["Success"] = "Successfully Updated The Record";
                            return RedirectToAction("State");
                        }
                    }
                }
                //CustomMethods.BindCountryList(model);
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                //CustomMethods.BindCountryList(model);
                return View(model);
                throw;
            }
        }

        public ActionResult ViewState(int id = 0, int pid = 0)
        {
            //CustomMethods.ValidateRoles("State");
            if (!Convert.ToBoolean(Session["Add"]) && !Convert.ToBoolean(Session["Edit"]))
                return View("ErrorPage", "Error");
            StateModel state = new StateModel();
            int take = 10;
            int skip = take * pid;
            state.PageID = pid;
            state.Current = pid + 1;
            ViewBag.c = state.PageID;
            if (id != 0)
            {
                var objState = new StateBLL { }.GetSubStateById(id);
                if (objState != null)
                {
                    state.StateId = objState.StateId;
                    state.StateName = objState.StateName;
                    state.CountryId = objState.CountryId;  //== null ? 0 : Convert.ToInt32(objcourse.CountryId);
                    state.CountryName = objState.CountryName;
                    state.IsActive = Convert.ToBoolean(objState.IsActive);
                }
            }
            return View(state);
        }

        public JsonResult ChangeStateStatus(int id)
        {
            bool Result = false;
            bool changestatus = new StateBLL { }.ChangeStatus(id);
            if (changestatus)
            {
                Result = true;

            }
            return Json(Result);
        }


        #endregion


        #region City
        public ActionResult City(int pid = 0, int cid = 0)
        {
            int take = 10;
            int skip = take * pid;
            CityModel model = new CityModel();
            model.PageID = pid;
            model.Current = pid + 1;
            ViewBag.pid = pid;
            IEnumerable<CityModel> Courses = new List<CityModel>();
            //CustomMethods.ValidateRoles("City");
            var Citieslist = new CityBLL { }.GetAllCities(skip, take);
            if (cid != 0)
            {
                var sortedlist = new CityBLL { }.GetAllCities(skip, take, cid);
                double count = Convert.ToDouble(sortedlist.Count);
                var res = count / take;
                model.Pagecount = (int)Math.Ceiling(res);
                model.CityList = sortedlist.Select(x => new CityModel
                {
                    CityId = x.CityId,
                    CityName = x.CityName,
                    StateId = x.StateId,
                    IsActive = Convert.ToBoolean(x.IsActive)
                }).ToList();
            }
            else
            {
                if (Citieslist != null)
                {
                    double count = Convert.ToDouble(new CityBLL { }.GetPageCount());
                    var res = count / take;
                    model.Pagecount = (int)Math.Ceiling(res);
                    model.CityList = Citieslist.Select(x => new CityModel
                    {
                        CityId = x.CityId,
                        CityName = x.CityName,
                        StateId = x.StateId,
                        IsActive = Convert.ToBoolean(x.IsActive)
                    }).ToList();
                }
            }
            return View(model);
        }

        public ActionResult AddEditCity(int id = 0, int pid = 0)
        {
            //CustomMethods.ValidateRoles("City");
            if (!Convert.ToBoolean(Session["Add"]) && !Convert.ToBoolean(Session["Edit"]))
                return View("ErrorPage", "Error");
            CityModel CityModel = new CityModel();
            int take = 10;
            int skip = take * pid;
            CityModel.PageID = pid;
            CityModel.Current = pid + 1;
            ViewBag.c = CityModel.PageID;
            if (id != 0)
            {
                var objcity = new CityBLL { }.GetSubCityById(id);
                if (objcity != null)
                {
                    CityModel.CityId = objcity.CityId;
                    CityModel.CityName = objcity.CityName;
                    CityModel.StateId = objcity.StateId;
                    CityModel.IsActive = Convert.ToBoolean(objcity.IsActive);
                }
            }
            //CustomMethods.BindStateList(CityModel);
            return View(CityModel);
        }

        [HttpPost]
        public ActionResult AddEditCity(CityModel model)
        {
            int result = 0;
            CityBLL CityBLL = new CityBLL();
            try
            {
                if (model.CityId == 0)
                {
                    if (!Convert.ToBoolean(Session["Add"]))
                        return View("ErrorPage");
                }
                else
                {
                    if (!Convert.ToBoolean(Session["Edit"]))
                        return View("ErrorPage");
                }
                if (ModelState.IsValid)
                {
                    if (model.CityId == 0)
                    {
                        var checkDuplicate = objdb.Cities.Where(x => x.CityName == model.CityName).FirstOrDefault();
                        if (checkDuplicate == null)
                        {
                            int res = new CityBLL { }.AddEditCity(new CityModel
                            {
                                CityName = model.CityName,
                                StateId = model.StateId,
                                IsActive = model.IsActive,
                                CreatedBy = Convert.ToInt32(Session["UserId"]),
                            });
                            if (res != 0)
                            {
                                Session["Success"] = "Successfully Added The Record";
                                return RedirectToAction("City");
                            }
                        }
                        Session["Error"] = "Record Already Exists";
                        return RedirectToAction("City");
                    }


                    else
                    {
                        if (model.CityId == 0)
                        {
                            Session["Error"] = "Record Already Exists";
                            return RedirectToAction("AddEditCity");
                        }
                        else
                        {
                            model.UpdatedBy = Convert.ToInt32(Session["UserId"]);
                            result = CityBLL.AddEditCity(model);

                            if (result != 0)
                            {
                                Session["Success"] = "Successfully Updated The Record";
                                return RedirectToAction("City");
                            }
                        }
                    }

                }
                //CustomMethods.BindStateList(model);
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                //CustomMethods.BindCountryList(model);
                return View(model);
                throw;
            }
        }

        public ActionResult ViewCity(int id = 0, int pid = 0)
        {

            //CustomMethods.ValidateRoles("City");
            if (!Convert.ToBoolean(Session["Add"]) && !Convert.ToBoolean(Session["Edit"]))
                return View("ErrorPage", "Error");
            CityModel city = new CityModel();
            int take = 10;
            int skip = take * pid;
            city.PageID = pid;
            city.Current = pid + 1;
            ViewBag.c = city.PageID;
            if (id != 0)
            {
                var objcity = new CityBLL { }.GetSubCityById(id);
                if (objcity != null)
                {
                    city.CityId = objcity.CityId;
                    city.CityName = objcity.CityName;
                    city.StateName = objcity.StateName;
                    city.IsActive = Convert.ToBoolean(objcity.IsActive);
                }
            }
            return View(city);
        }

        public JsonResult ChangeCityStatus(int id)
        {
            bool Result = false;
            bool changestatus = new CityBLL { }.ChangeStatus(id);
            if (changestatus)
            {
                Result = true;

            }
            return Json(Result);
        }
        #endregion
    }
}
