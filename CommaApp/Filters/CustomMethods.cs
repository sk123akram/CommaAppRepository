using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using CommaApp.BLL;
using CommaApp.CommonUtility;
using CommaApp.DAL;

namespace CommaApp.Filters
{
    static public class CustomMethods
    {
        public static void BindCountryList<T>(T model)
        {
            try
            {
                var cities = new CountryBLL { }.GetAllCountry();
                if (cities != null)
                {
                    model.GetType().GetProperty("CountryList").SetValue(model, cities.Select(x => new SelectListItem { Value = x.CountryId.ToString(), Text = x.CountryName }));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void BindStateList<T>(T model)
        {
            try
            {
                var cities = new StateBLL { }.GetAllState();
                if (cities != null)
                {
                    model.GetType().GetProperty("StateList").SetValue(model, cities.Select(x => new SelectListItem { Value = x.StateId.ToString(), Text = x.StateName }));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void BindCityList<T>(T model)
        {
            try
            {
                var cities = new CityBLL { }.GetAllCities();
                if (cities != null)
                {
                    model.GetType().GetProperty("CityList").SetValue(model, cities.Select(x => new SelectListItem { Value = x.CityId.ToString(), Text = x.CityName }));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public static void BindVehcileType<T>(T model)
        //{
        //    try
        //    {
        //        var vehciletype = new VehicleTypeBLL { }.GetAllVehicleType();
        //        if (vehciletype != null)
        //        {
        //            model.GetType().GetProperty("VehcileTypeList").SetValue(model, vehciletype.Select(x => new SelectListItem { Value = x.VehicleTypeId.ToString(), Text = x.VehicleTypeName }));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static void BindPackageList<T>(T model)
        //{
        //    try
        //    {
        //        var package = new PackageBLL { }.GetAllPackages();
        //        if (package != null)
        //        {
        //            model.GetType().GetProperty("PackageList").SetValue(model, package.Select(x => new SelectListItem { Value = x.packageid.ToString(), Text = x.packagename }));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static void BindAirPortList<T>(T model)
        //{
        //    try
        //    {
        //        var airPort = new AirPortBLL { }.GetAllAirPort();
        //        if (airPort != null)
        //        {
        //            model.GetType().GetProperty("AirPortList").SetValue(model, airPort.Select(x => new SelectListItem { Value = x.AirPortId.ToString(), Text = x.AirPortName }));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static void BindBookingStatusList<T>(T model)
        //{
        //    try
        //    {
        //        var Bookingstatus = new BookingStatusBLL { }.GetAllBookingStatus();
        //        if (Bookingstatus != null)
        //        {
        //            model.GetType().GetProperty("BookingStatusList").SetValue(model, Bookingstatus.Select(x => new SelectListItem { Value = x.BookingStatusId.ToString(), Text = x.BookingStatusName }));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static void BindOutstationList<T>(T model)
        //{
        //    try
        //    {
        //        var List = new OutStationBLL { }.GetAllOutSatations();
        //        if (List != null)
        //        {
        //            model.GetType().GetProperty("outstationlist").SetValue(model, List.Select(x => new SelectListItem { Value = x.outstationid.ToString(), Text = x.outstationname }));
        //            model.GetType().GetProperty("outstationlist1").SetValue(model, List.Select(x => new SelectListItem { Value = x.outstationid.ToString(), Text = x.outstationname }));
        //            model.GetType().GetProperty("outstationlist2").SetValue(model, List.Select(x => new SelectListItem { Value = x.outstationid.ToString(), Text = x.outstationname }));
        //            model.GetType().GetProperty("outstationlist3").SetValue(model, List.Select(x => new SelectListItem { Value = x.outstationid.ToString(), Text = x.outstationname }));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static void BindServiceTypeList<T>(T model)
        //{
        //    try
        //    {
        //        var service = new ServiceTypeBLL { }.GetAllServiceType();
        //        if (service != null)
        //        {
        //            model.GetType().GetProperty("ServiceTypeList").SetValue(model, service.Select(x => new SelectListItem { Value = x.ServiceId.ToString(), Text = x.ServiceTypeName }));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static void BindVehicleList<T>(T model)
        //{
        //    try
        //    {
        //        var Vehicle = new VehiclesBLL { }.GetAllVehcile();
        //        if (Vehicle != null)
        //        {
        //            model.GetType().GetProperty("VehicleList").SetValue(model, Vehicle.Select(x => new SelectListItem { Value = x.VehicleId.ToString(), Text = x.VehicleName }));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static void BindVendorList<T>(T model)
        //{
        //    try
        //    {
        //        var Vendor = new VendorBLL { }.GetAllVendor();
        //        if (Vendor != null)
        //        {
        //            model.GetType().GetProperty("VendorList").SetValue(model, Vendor.Select(x => new SelectListItem { Value = x.VendorId.ToString(), Text = x.VendorName }));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static void BindVendorCabsByVndrId<T>(T model)
        //{
        //    try
        //    {
        //        var Vendor = new VendorBLL { }.GetAllVendor();
        //        if (Vendor != null)
        //        {
        //            model.GetType().GetProperty("VendorList").SetValue(model, Vendor.Select(x => new SelectListItem { Value = x.VendorId.ToString(), Text = x.VendorName }));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static void BindDriverList<T>(T model)
        //{
        //    try
        //    {
        //        var driver = new DriverBLL { }.GetAllDriver();
        //        if (driver != null)
        //        {
        //            model.GetType().GetProperty("DriverList").SetValue(model, driver.Select(x => new SelectListItem { Value = x.DriverId.ToString(), Text = x.FirstName }));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static void BindDriverListByVendorId<T>(T model, int? id)
        //{
        //    try
        //    {
        //        var driver = new DriverBLL { }.GetAllDriverByVendorId(id);
        //        if (driver != null)
        //        {
        //            model.GetType().GetProperty("DriverList").SetValue(model, driver.Select(x => new SelectListItem { Value = x.DriverId.ToString(), Text = x.FirstName }));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static void BindVehicleTypeList<T>(T model)
        //{
        //    try
        //    {
        //        var VehicleType = new VehicleTypeBLL { }.GetAllVehicleType();
        //        if (VehicleType != null)
        //        {
        //            model.GetType().GetProperty("VehicleTypeList").SetValue(model, VehicleType.Select(x => new SelectListItem { Value = x.VehicleTypeId.ToString(), Text = x.VehicleTypeName }));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static void BindVehicleList<T>(T model)
        //{
        //    try
        //    {
        //        var VehicleType = new VehiclesBLL { }.GetAllVehcile();
        //        if (VehicleType != null)
        //        {
        //            model.GetType().GetProperty("VehicleList").SetValue(model, VehicleType.Select(x => new SelectListItem { Value = x.VehicleId.ToString(), Text = x.VehicleNumber }));
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public static void BindVehicleListByVendorId<T>(T model, int? id)
        //{
        //    try
        //    {
        //        var VehicleType = new VehiclesBLL { }.GetAllVehcile().Where(x => x.VendorId == id && x.IsMapped == false);
        //        if (VehicleType != null)
        //        {
        //            model.GetType().GetProperty("VehicleList").SetValue(model, VehicleType.Select(x => new SelectListItem { Value = x.VehicleId.ToString(), Text = x.VehicleNumber }));
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public static void BindTimingList<T>(T model)
        //{
        //    var temp = new List<SelectListItem>();
        //    DateTime dtStart = Convert.ToDateTime("2014-08-05 00:00:00.000");
        //    DateTime dtEnd = Convert.ToDateTime("2014-08-06 00:00:00.000");
        //    int i = 0;
        //    while (i <= 95)
        //    {
        //        temp.Add(new SelectListItem { Text = dtStart.ToString("HH:mm") });
        //        dtStart = dtStart.AddMinutes(15);
        //        i++;
        //    }
        //    if (temp != null)
        //    {
        //        model.GetType().GetProperty("TimingList").SetValue(model, temp.Select(x => new SelectListItem { Value = x.Value, Text = x.Text }));
        //    }
        //}

        internal static void RoleManagement(int pageid)
        {
            try
            {
                int roleid = Convert.ToInt32(HttpContext.Current.Session["UserId"]);
                var rm = new RolesBLL { }.GetRoleManagement(pageid, roleid);
                if (rm != null)
                {
                    HttpContext.Current.Session["IsAdd"] = rm.IsAdd;
                    HttpContext.Current.Session["IsEdit"] = rm.IsEdit;
                    HttpContext.Current.Session["IsDelete"] = rm.IsDelete;
                    HttpContext.Current.Session["IsView"] = rm.IsView;
                    HttpContext.Current.Session["IsEnable"] = rm.IsEnable;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static int GetPageIDByPageName(string pagename)
        {
            try
            {
                string str = HttpContext.Current.Server.MapPath("~/Areas/Admin/RoleManagement.xml");
                var xml = XDocument.Load(str);
                var id = xml.Root.Elements("Page").Where(x => (string)x.Attribute("Name") == pagename)
                                .Select(x => x.Attribute("Id").Value).SingleOrDefault();
                return Convert.ToInt32(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static bool ValidateRoles(string pagename)
        {
            try
            {
                RoleManagement(GetPageIDByPageName(pagename));
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}