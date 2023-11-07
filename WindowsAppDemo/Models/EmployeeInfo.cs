using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAppDemo.Models
{
    public class EmployeeInfo
    {
        public int Id { get; set; }
        public string empCode { get; set; }
        public string empName { get; set; }
        public string designation { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int? age { get; set; }
    }
}
