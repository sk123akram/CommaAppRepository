using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace CommaApp.CommonUtility
{
    public class StateModel
    {
        public int StateId { get; set; }
        public int? CountryId { get; set; }
        public string StateName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string CountryName { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public int Pagecount { get; set; }
        public int PageID { get; set; }
        public int Current { get; set; }
        public IEnumerable<SelectListItem> CountryNames { get; set; }
        public List<StateModel> StateList { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
    }
}
