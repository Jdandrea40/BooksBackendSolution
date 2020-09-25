using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksBackend.Models.Employees
{
    public class PostEmployeeCreate
    {
            public string Name { get; set; }
            public string Department { get; set; }
            public int StartingSalary { get; set; }

    }
}
