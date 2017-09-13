using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommaApp.CommonUtility
{
    public class RoleAssignmentModel
    {
        public int UserTypeId { get; set; }
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public bool IsActive { get; set; }
        public int? ModuleId { get; set; }
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsView { get; set; }
        public bool IsEnable { get; set; }

        public string UserTypeName { get; set; }
        public int RoleAssgnId { get; set; }
        public string ModuleName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public IEnumerable<RoleAssignmentModel> RoleAssignment { get; set; }
        public IEnumerable<UserTypeModel> RolesModel { get; set; }
        public List<RoleAssignmentModel> RoleAssgObj { get; set; }
        public List<RoleAssignmentModel> moduleDetails { get; set; }
        public List<UserTypeModel> roleModelObj { get; set; }
        public List<int> Moduleid_RoleTable { get; set; }
        public List<int> ModulesList { get; set; }
        public List<int> Modules { get; set; }
        public List<RoleAssignmentModel> roles { get; set; }
        public List<int> FinalModelId { get; set; }
        public List<RoleAssignmentModel> RoleList { get; set; }
        public List<RoleAssignmentModel> ModuleList { get; set; }
        public List<string> roAss { get; set; }
        public List<ModulesModel> ModList { get; set; }
        // public int PageID { get; set; }

        public int Pagecount { get; set; }
        public int PageID { get; set; }
        public int Total { get; set; }
        public int Current { get; set; }

    }
}