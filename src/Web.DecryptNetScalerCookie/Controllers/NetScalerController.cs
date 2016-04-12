using System.Web.Http;
using NetScalerCookieDecrypter;

namespace Web.DecryptNetScalerCookie.Controllers
{
  public class NetScalerController : ApiController
  {
    public NetScalerDecryptedCookie GetInfo(string cookie)
    {
      return DecryptNetscalerCookie.DecryptCookie(cookie, false);
    }
  }
}
