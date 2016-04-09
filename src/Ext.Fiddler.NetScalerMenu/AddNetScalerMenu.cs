using System;
using System.Windows.Forms;
using Fiddler;

[assembly: Fiddler.RequiredVersion("2.4.2.6")]
namespace Ext.Fiddler.NetScalerMenu
{
  public class AddNetScalerMenu : IFiddlerExtension
  {

    private MenuItem mnuNetScaler;
    private MenuItem miRequestNetScaler;
    private MenuItem miResponseNetScaler;
    private MenuItem miHostNameLookup;


    #region IFiddlerExtension Members

    public void OnLoad()
    {
      this.mnuNetScaler = new MenuItem("NetScaler");
      this.miRequestNetScaler = new MenuItem("Request Cookie");
      this.miResponseNetScaler = new MenuItem("Response Cookie");
      this.miHostNameLookup = new MenuItem("Server Name Lookup");

      //if (FiddlerApplication.Prefs["extensions.miRequestNetScaler.enabled"] == null)
      //  FiddlerApplication.Prefs.SetBoolPref("extensions.miRequestNetScaler.enabled", true);
      //if (FiddlerApplication.Prefs["extensions.miResponseNetScaler.enabled"] == null)
      //  FiddlerApplication.Prefs.SetBoolPref("extensions.miResponseNetScaler.enabled", true);
      if (FiddlerApplication.Prefs["extensions.miHostNameLookup.enabled"] == null)
        FiddlerApplication.Prefs.SetBoolPref("extensions.miHostNameLookup.enabled", false);

      //this.miRequestNetScaler.Checked = FiddlerApplication.Prefs.GetBoolPref("extensions.miRequestNetScaler.enabled", false);
      //this.miResponseNetScaler.Checked = FiddlerApplication.Prefs.GetBoolPref("extensions.miResponseNetScaler.enabled", false);
      this.miHostNameLookup.Checked = FiddlerApplication.Prefs.GetBoolPref("extensions.miHostNameLookup.enabled", false);

      mnuNetScaler.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                //miRequestNetScaler,miResponseNetScaler, new MenuItem("-"),
                miHostNameLookup});

      miRequestNetScaler.Click += new EventHandler(miRequestNetScaler_Click);
      miResponseNetScaler.Click += new EventHandler(miResponseNetScaler_Click);
      miHostNameLookup.Click += new EventHandler(miHostNameLookup_Click);
      FiddlerApplication.UI.Menu.MenuItems.Add(mnuNetScaler);


    }

    public void OnBeforeUnload()
    {
    }

    void miHostNameLookup_Click(object sender, EventArgs e)
    {
      miHostNameLookup.Checked = !miHostNameLookup.Checked;
      FiddlerApplication.Prefs.SetBoolPref("extensions.miHostNameLookup.enabled", miHostNameLookup.Checked);
    }

    void miRequestNetScaler_Click(object sender, EventArgs e)
    {
      miRequestNetScaler.Checked = !miRequestNetScaler.Checked;
      FiddlerApplication.Prefs.SetBoolPref("extensions.miRequestNetScaler.enabled", miRequestNetScaler.Checked);
    }

    void miResponseNetScaler_Click(object sender, EventArgs e)
    {
      miResponseNetScaler.Checked = !miResponseNetScaler.Checked;
      FiddlerApplication.Prefs.SetBoolPref("extensions.miResponseNetScaler.enabled", miResponseNetScaler.Checked);
    }

    #endregion
  }
}
