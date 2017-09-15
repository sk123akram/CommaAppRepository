using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommaApp.CommonUtility
{
   public class UserModel
    {
        public int UserId { get; set; }
        public int? UserTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UserTypeName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public bool IsActive { get; set; }
        public string ConfirmPassword { get; set; }


        public string OldPassword { get; set; }
        public int PageID { get; set; }
        public int Current { get; set; }
        public int Pagecount { get; set; }
        public List<UserModel> AdminList { get; set; }
        public string lblmessage { get; set; }

        public int? RoleId { get; set; }
        public int AdminId { get; set; }
        public string GUID { get; set; }
        public bool IsConfirmed { get; set; }



    }
}
