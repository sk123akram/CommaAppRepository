using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommaApp.CommonUtility
{
    public class LogonModel
    {
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string Returnurl { get; set; }

        public int RoleId { get; set; }
        public int AdminId { get; set; }
        public string GUID { get; set; }
        public bool IsConfirmed { get; set; }


    }
}
