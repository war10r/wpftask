using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Task.Models
{
    internal class DataStorage
    {
        public static User CurrentUser { get; set; }
        public static Request CurrentRequest { get; set; }
    }
}
