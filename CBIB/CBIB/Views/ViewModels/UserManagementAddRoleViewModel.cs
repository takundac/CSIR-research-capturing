using Microsoft.AspNetCore.Mvc.Rendering;

namespace CBIB.Views.ViewModels
{
    public class UserManagementAddRoleViewModel
    {
        public string UserId { get; set; }
        public string NewRole { get; set; }
        public SelectList Roles { get; set; }
        public string Email { get; set; }
        public long ID { get; set; }
    }
}
