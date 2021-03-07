using HWMultipleRows.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HWMultipleRows.Web.Models
{
    public class PeopleViewModel
    {
        public List<Person> People { get; set; }
        public string Alert { get; set; }
    }
}
