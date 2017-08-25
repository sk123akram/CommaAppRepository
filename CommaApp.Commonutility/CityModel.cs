using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;



namespace CommaApp.CommonUtility
{
    public class CityModel
    {
        public int CityId { get; set; }
        public int? StateId { get; set; }
        public string CityName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string StateName { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public int Pagecount { get; set; }
        public int PageID { get; set; }
        public int Current { get; set; }
        public List<CityModel> CityList { get; set; }
        //public IEnumerable<SelectListItem> StateList { get; set; }

    }
}
