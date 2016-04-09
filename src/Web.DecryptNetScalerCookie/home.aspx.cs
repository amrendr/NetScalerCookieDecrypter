using System;
using System.Web.UI;
using NetScalerCookieDecrypter;

namespace Web.DecryptNetScalerCookie
{
  public partial class home : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (IsPostBack)
      {
        string cookie = this.TextBox1.Text;
        NetScalerDecryptedCookie info = null;
        try
        {
          info = DecryptNetscalerCookie.DecryptCookie(cookie, false);
        }
        catch (Exception) { }

        if (info != null)
        {
          this.Literal1.Text = info.ServiceGroupName;
          this.Literal2.Text = info.ServerIP;
          this.Literal3.Text = info.ServerPort;
        }
        else
        {
          this.Literal1.Text = "";
          this.Literal2.Text = "";
          this.Literal3.Text = "";
        }

        this.TextBox1.Focus();
      }
    }
  }
}