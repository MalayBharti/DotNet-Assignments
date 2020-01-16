using LibraryManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonService commonService = new CommonService();
            commonService.Service();
        }
    }
}
