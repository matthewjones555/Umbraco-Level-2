using System.Web.Mvc;
using Umbraco.Course.Models;
using Umbraco.Web.Mvc;

namespace Umbraco.Course.Controllers
{
    public class RegisterController : SurfaceController
    {
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();
            
            if (Services.MemberService.GetByEmail(model.Email) != null)
            {
                ModelState.AddModelError("Email", "A member with that email already exists.  Please try logging in, or using the reset password facility.");
                return CurrentUmbracoPage();
            }

            var member = Services.MemberService.CreateMemberWithIdentity(model.Email, model.Email, model.Name, "IntranetMember");

            member.SetValue("biography", model.Biography);
            member.SetValue("avatar", model.Avatar);

            Services.MemberService.Save(member);
            Services.MemberService.AssignRole(member.Id, "Intranet");
            Services.MemberService.SavePassword(member, model.Password);

            Members.Login(member.Username, model.Password);

            return Redirect("/");
        }
    }
}
