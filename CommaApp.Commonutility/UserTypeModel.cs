using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommaApp.CommonUtility
{
   public class UserTypeModel
    {
       public int UserTypeId { get; set; }
       public string UserTypeName { get; set; }
       public DateTime? UpdatedDate { get; set; }
       public DateTime? CreatedDate { get; set; }
       public bool IsActive { get; set; }
       public int? CreatedBy { get; set; }
       public int? UpdatedBy { get; set; }


       public int Pagecount { get; set; }
       public int PageID { get; set; }
       public int Current { get; set; }
       public List<RoleAssignmentModel> RoleAssignments { get; set; }
       public List<ModulesModel> ModulesList { get; set; }
       public List<UserTypeModel>UserTypeList { get; set; }
    }
}
