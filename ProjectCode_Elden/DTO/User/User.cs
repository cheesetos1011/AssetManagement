using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCode.DTO.User
{
    public class User
    {
        public class UserData
        {
            public string staffcode { get; set; }
            public string username { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string dob { get; set; }
            public string joinedDate { get; set; }
            public bool gender { get; set; }
            public string location { get; set; }
            public int logCount { get; set; }
            public bool isActive { get; set; }
            public bool isAdmin { get; set; }
            public string token { get; set; }


        }

    }
}
