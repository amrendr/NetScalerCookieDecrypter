using System;
using Fiddler;

namespace Ext.Fiddler.NetScalerInspector
{
  public class RequestInspectors : NetScalerCookieInspector, IRequestInspector2
  {
    public bool bReadOnly
    {
      get { return true; }
      set { }
    }

    public bool bDirty
    {
      get { return false; }
    }

    public byte[] body
    {
      get { return null; }
      set { }
    }

    public void Clear()
    {
      this.myControl.textBox1.Clear();
    }

    public HTTPRequestHeaders headers
    {
      get
      {
        return null;
      }
      set
      {
        this.myControl.textBox1.Clear();
        if (value != null)
        {
          string result = "";
          foreach (HTTPHeaderItem hTTPHeaderItem in value)
          {
            if (string.Equals(hTTPHeaderItem.Name, "Cookie", StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(hTTPHeaderItem.Name, "Origin-Cookie", StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(hTTPHeaderItem.Name, "Cookie2", StringComparison.InvariantCultureIgnoreCase))
            {
              result = GetNetScalerCookieInfo(hTTPHeaderItem);
            }
          }

          if (result.Length < 1)
          {
            result = "This request did not send any NetScaler cookie data.";
          }
          this.myControl.textBox1.Text = result;
          return;
        }
        else
        {
          return;
        }
      }
    }

  }

  public class ResponseInspectors : NetScalerCookieInspector, IResponseInspector2
  {
    public bool bReadOnly
    {
      get { return true; }
      set { }
    }

    public bool bDirty
    {
      get { return false; }
    }

    public byte[] body
    {
      get { return null; }
      set { }
    }

    public void Clear()
    {
      this.myControl.textBox1.Clear();
    }

    public HTTPResponseHeaders headers
    {
      get
      {
        return null;
      }
      set
      {
        this.myControl.textBox1.Clear();
        if (value != null)
        {
          string result = "";
          foreach (HTTPHeaderItem hTTPHeaderItem in value)
          {
            if (string.Equals(hTTPHeaderItem.Name, "Set-Cookie", StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(hTTPHeaderItem.Name, "Set-Cookie2", StringComparison.InvariantCultureIgnoreCase))
            {
              result = GetNetScalerCookieInfo(hTTPHeaderItem);
            }
          }

          if (result.Length < 1)
          {
            result = "This reponse did not set any NetScaler cookie data.";
          }
          this.myControl.textBox1.Text = result;
          return;
        }
        else
        {
          return;
        }
      }
    }

  }
}
