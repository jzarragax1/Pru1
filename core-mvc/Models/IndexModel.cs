using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace core_mvc.Models
{
    public class IndexModel
    {
        //public int id { get; set; } 
        public string dni { get; set; } 
        public string plantaDesc { get; set; }

    }

}
