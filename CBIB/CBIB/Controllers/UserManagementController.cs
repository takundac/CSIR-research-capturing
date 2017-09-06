using CBIB.Data;
using CBIB.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBIB.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public UserManagementController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            var vm = new UserManagementIndexViewModel
            {
                Users = _dbcontext.Users.OrderBy(u => u.Email).ToList()
            };
            return View(vm);
        }
        
    }
}
