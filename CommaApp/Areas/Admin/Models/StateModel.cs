using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommaApp.Areas.Admin.Models
{
    public class StateModel
    {
        public int StateId { get; set; }
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Please enter your country")]
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        //public int Pagecount { get; set; }
        //public int PageID { get; set; }
        //public int Current { get; set; }
        public List<StateModel> States { get; set; }
        //public IEnumerable<SelectListItem> State { get; set; }
        //public IEnumerable<SelectListItem> CityNames { get; set; }

    }
}