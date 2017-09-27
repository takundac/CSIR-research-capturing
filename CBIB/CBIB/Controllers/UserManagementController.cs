using CBIB.Data;
using CBIB.Models;
using CBIB.Views.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CBIB.Controllers
{
    //[Authorize(Roles="Global Administrator")]

    public class UserManagementController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly CBIBContext _CBIBContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementController(
            ApplicationDbContext dbContext,
            CBIBContext CBIBContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _CBIBContext = CBIBContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var vm = new UserManagementIndexViewModel
            {
                Users = _dbContext.Users.OrderBy(u => u.Email).Include(u => u.Roles).ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> AddRole(string id)
        {
            var user = await GetUserById(id);
            var vm = new UserManagementAddRoleViewModel
            {
                Roles = GetAllRoles(),
                UserId = id,
                Email = user.Email
            };
            return View(vm);
        }
        //[HttpGet]
        //public async Task<IActionResult> AddNode(string id)
        //{
        //    var user = await GetUserById(id);
        //    var vm = new NodesAddRoleViewModel
        //    {
        //        Nodes = GetAllNodes(),
        //        UserId = id,
        //        Email = user.Email
        //    };
        //    return View(vm);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddRole(UserManagementAddRoleViewModel rvm)
        //{
        //    var user = await GetUserById(rvm.UserId);
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _userManager.AddToRoleAsync(user, rvm.NewRole);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(error.Code, error.Description);
        //        }
        //    }
        //    rvm.Email = user.Email;
        //    rvm.Roles = GetAllRoles();
        //    return View(rvm);

        //}

        private async Task<ApplicationUser> GetUserById(string id) =>
            await _userManager.FindByIdAsync(id);

        private SelectList GetAllRoles() => new SelectList(_roleManager.Roles.OrderBy(r => r.Name));

        //private SelectList GetAllNodes() => new SelectList(_CBIBContext.Node.ToList);

        public IActionResult AddNode()
        {
            List<Node> nodes = new List<Node>();

            nodes = (from Name in _CBIBContext.Node select Name).ToList();

            nodes.Insert(0, new Node
            {
                ID = 0,
                Name = "Select"
            });

            ViewBag.ListOfNodes = nodes;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Node node)
        {
            if (node.ID == 0)
            {
                ModelState.AddModelError("", "Select Country");
            }

            long SelectValue = node.ID;

            ViewBag.SelectedValue = node.ID;

            // ------- Setting Data back to ViewBag after Posting Form ------- //

            List<Node> nodes = new List<Node>();

            nodes = (from product in _CBIBContext.Node select product).ToList();

            nodes.Insert(0, new Node
            {
                ID = 0,
                Name = "Select"
            });

            ViewBag.ListOfNodes = nodes;

            return View();
        }


    }
}
