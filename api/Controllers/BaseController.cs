using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class BaseController : Controller
    {
        public string UserID { get; private set; }
        public string Email { get; private set; }
        public string UserData { get; private set; }
        public List<string> Roles { get; private set; }

        [NonAction]
        public void GetUserIdentity()
        {
            UserID = "3b51e708-f9ff-4e4e-95bf-535085707374";
            Email = "admin@techdemo.io";
        }
    }
}