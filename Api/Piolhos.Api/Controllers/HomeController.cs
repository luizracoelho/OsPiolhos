using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web.Http;

namespace Piolhos.Api.Controllers
{
    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok($"Api works on ip {GetIPAddress()}!");
        }

        protected string GetIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            return host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault().ToString();
        }
    }
}
