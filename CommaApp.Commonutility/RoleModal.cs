using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommaApp.CommonUtility;

namespace CommaApp.CommonUtility
{
    public class RoleModal
    {
        public RoleModal()
        {
            Rolemanages = new List<RolemanagementModel>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<RolemanagementModel> Rolemanages { get; set; }
    }

    public class RolemanagementModel
    {
        public int RolemanagementID { get; set; }
        public int? RoleID { get; set; }
        public int PageID { get; set; }
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsView { get; set; }
        public bool IsEnable { get; set; }

    }
}
