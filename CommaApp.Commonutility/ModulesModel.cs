using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CommaApp.CommonUtility
{
    public class ModulesModel
    {
        [ScaffoldColumn(false)]
        public int ModuleId { get; set; }

        [Required(ErrorMessage = "Module Name cannot be null")]
        [StringLength(50)]
        public string ModuleName { get; set; }

        
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int PageID { get; set; }
        public int Current { get; set; }
        public int Pagecount { get; set; }
        public int PageSize { get; set; }


        public List<ModulesModel> ModuleList { get; set; }
    }
}