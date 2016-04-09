using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fiddler;
using NetScalerCookieDecrypter;

[assembly: Fiddler.RequiredVersion("2.4.2.6")]
namespace Ext.Fiddler.NetScalerInspector
{
  public class NetScalerCookieInspector : Inspector2
  {
    protected NetscalerCookieInfo myControl;

    public NetScalerCookieInspector()
    {

    }

    protected string GetNetScalerCookieInfo(HTTPHeaderItem httpHeaderItem)
    {
      string httpHeaderdata = httpHeaderItem.Value.ToString();
      StringBuilder stringBuilder = new StringBuilder();

      if (httpHeaderdata.Contains("NSC_"))
      {
        string[] cookies = httpHeaderdata.Split(';');
        foreach (string cookie in cookies)
        {
          if (cookie.Contains("NSC_"))
          {
            stringBuilder.AppendLine("NetScaler Cookie: " + cookie.TrimStart());
            stringBuilder.AppendLine();
            stringBuilder.AppendLine(FormatCookie(cookie.TrimStart(), FiddlerApplication.Prefs.GetBoolPref("extensions.miHostNameLookup.enabled", false)));
          }
        }
      }
      return stringBuilder.ToString();
    }

    private string FormatCookie(string cookie, bool bResolveServerName)
    {
      NetScalerDecryptedCookie decryptedCookie = DecryptNetscalerCookie.DecryptCookie(cookie, bResolveServerName);

      if (decryptedCookie == null)
        return "Could not succesfully parse the cookie.";

      StringBuilder stringBuilder = new StringBuilder();
      if (!string.IsNullOrEmpty(decryptedCookie.ServiceGroupName))
        stringBuilder.AppendLine(String.Format("Service Group Name{0,2} {1}", ":", decryptedCookie.ServiceGroupName));

      if (!string.IsNullOrEmpty(decryptedCookie.ServerIP))
        stringBuilder.AppendLine(String.Format("Server IP{0,20} {1}", ":", decryptedCookie.ServerIP));

      if (!string.IsNullOrEmpty(decryptedCookie.ServerPort))
        stringBuilder.AppendLine(String.Format("Server Port{0,17} {1}", ":", decryptedCookie.ServerPort));

      if (!string.IsNullOrEmpty(decryptedCookie.ServerName))
        stringBuilder.AppendLine(String.Format("Server Name{0,15} {1}", ":", decryptedCookie.ServerName));

      return stringBuilder.ToString();
    }

    public override int GetOrder()
    {
      return 0;
    }

    public override void AddToTab(System.Windows.Forms.TabPage o)
    {
      myControl = new NetscalerCookieInfo(this);
      o.Text = "NetScaler Cookies";
      o.Controls.Add(this.myControl);
      o.Controls[0].Dock = System.Windows.Forms.DockStyle.Fill;
    }

    public override void SetFontSize(float flSizeInPoints)
    {
      if (this.myControl != null)
      {
        this.myControl.textBox1.Font = new Font(this.myControl.textBox1.Font.FontFamily, flSizeInPoints);
      }
    }
  }
}


