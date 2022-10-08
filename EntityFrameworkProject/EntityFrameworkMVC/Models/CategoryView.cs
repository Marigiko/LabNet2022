using EntityFrameworkProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkMVC.Models
{
    public class CategoryView
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Products> products { get; set; } 
    }
}