using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalCoreProject.ViewComponents.MemberLayout
{
    public class _MemberLayoutNavbar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _MemberLayoutNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public  IViewComponentResult Invoke()
        {
            // var values = await _userManager.FindByNameAsync(User.Identity.Name);
            //ViewBag.memberName = values.Name + " " + values.Surname;
            //ViewBag.memberPhone = values.PhoneNumber;
            //ViewBag.memberMail = values.Email;
            return View();
        }
    }
}
