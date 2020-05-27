using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSpace.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace DataSpace.Controllers
{
    [AuthorizeAdmin]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/Home/StatusCode/?code=103");
        }
        public IActionResult Review()
        {
            return Redirect("/Home/StatusCode/?code=103");
        }
        public IActionResult Accounts()
        {
            return Redirect("/Home/StatusCode/?code=103");
        }
    }
}