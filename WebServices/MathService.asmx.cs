using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace WebServices
{
    /// <summary>
    /// Summary description for MathService
    /// </summary>
    [WebService(Namespace = "http://itcraftsman.pl")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MathService : System.Web.Services.WebService
    {
        public UserAuth MyUserAuth { get; set; }


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod (Description =("Mnozeie liczb"))]
        [SoapHeader("MyUserAuth")]
        public double Multiply(double a, int b)
        {
            if (AuthorizeUser(MyUserAuth) == true)
                return a * b;
            else return 9999;
        }

        private static bool AuthorizeUser(UserAuth usr)
        {
            if (usr.UserName == "Odyn" && usr.Password == "itcraftsman")
            {
                return true;
            }
            return false;
        }
    }

    public class UserAuth : SoapHeader
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
