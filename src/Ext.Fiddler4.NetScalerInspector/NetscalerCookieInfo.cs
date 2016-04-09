using System;
using System.Drawing;
using System.Windows.Forms;
using Fiddler;

namespace Ext.Fiddler.NetScalerInspector
{
  public partial class NetscalerCookieInfo : UserControl
  {
    private Inspector2 m_owner;
    public RichTextBox textBox1;
    public NetscalerCookieInfo(Inspector2 o)
    {
      this.InitializeComponent();
      this.m_owner = o;
      this.textBox1.BackColor = CONFIG.colorDisabledEdit;
      if (CONFIG.flFontSize != this.textBox1.Font.Size)
      {
        this.textBox1.Font = new Font(this.textBox1.Font.FontFamily, CONFIG.flFontSize);
      }
    }

    private void NetscalerCookieInfo_Load(object sender, EventArgs e)
    {

    }
  }
}
