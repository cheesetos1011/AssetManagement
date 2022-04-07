using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCode.DTO.User
{
    public class User
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Data
        {
            public int id { get; set; }
            public string staffcode { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public DateTime dob { get; set; }
            public DateTime joinedDate { get; set; }
            public bool gender { get; set; }
            public string location { get; set; }
            public int logCount { get; set; }
            public bool isActive { get; set; }
            public bool isAdmin { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
        }

        public class UserList
        {
            public int pageNumber { get; set; }
            public int pageSize { get; set; }
            public int firstPage { get; set; }
            public int lastPage { get; set; }
            public int totalPages { get; set; }
            public int totalRecords { get; set; }
            public int nextPage { get; set; }
            public int previousPage { get; set; }
            public string sortType { get; set; }
            public string sortBy { get; set; }
            public string searchBy { get; set; }
            public string searchValue { get; set; }
            public List<Data> data { get; set; }
            public bool succeeded { get; set; }
            public object errors { get; set; }
            public object message { get; set; }
        }



    }
}
