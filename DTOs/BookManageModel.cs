using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Library_Management_FA23_BL5.DTOs
{
    internal class BookManageModel
    {
        public int TitleId { get; set; }
        public string? BookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public int InStock { get; set; }
        public int NumberOfPages { get; set; }
        public string? Condition { get; set; }
    }
}
