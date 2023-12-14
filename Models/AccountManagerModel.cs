using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Library_Management_FA23_BL5.Models
{
    internal class AccountManagerModel
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Mail { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
