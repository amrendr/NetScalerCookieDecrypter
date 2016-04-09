using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace NetScalerCookieDecrypter
{
  public class DecryptNetscalerCookie
  {

    public static NetScalerDecryptedCookie DecryptCookie(string cookie, bool bResolveServerName)
    {
      string[] parts = ParseCookie(cookie);

      if (parts == null)
        return null;

      string serverIP = DecryptServerIP(parts[2]);

      return new NetScalerDecryptedCookie(DecryptServiceName(parts[1]), serverIP, DecryptServerPort(parts[3]), bResolveServerName ? ResolveServerName(serverIP) : "");
    }

    private static string[] ParseCookie(string cookie)
    {
      Regex regex = new Regex("NSC_([a-zA-Z0-9-_.]*)=[0-9a-f]{8}([0-9a-f]{8}).*([0-9a-f]{4})$");
      Regex regex2 = new Regex("[0-9a-f]{8}([0-9a-f]{8}).*([0-9a-f]{4})$");
      string[] parts = null;

      if (regex.IsMatch(cookie))
        parts = regex.Split(cookie);
      else if (regex2.IsMatch(cookie))
        parts = regex.Split("NSC_=" + cookie);

      if (parts.Length == 1)
        return null;

      return parts;
    }

    private static string DecryptServiceName(string servicename)
    {
      return SubstitutionDecrypt(servicename, -1);
    }

    private static string SubstitutionDecrypt(string value, int shift)
    {
      char[] buffer = value.ToCharArray();
      for (int i = 0; i < buffer.Length; i++)
      {
        char letter = buffer[i];
        letter = 'a' <= letter && letter <= 'z' ? (letter + shift) < 'a' ? (char)(letter + shift + 26) : (letter + shift) > 'z' ? (char)(letter + shift - 26) : (char)(letter + shift) : letter;
        letter = 'A' <= letter && letter <= 'Z' ? (letter + shift) < 'A' ? (char)(letter + shift + 26) : (letter + shift) > 'Z' ? (char)(letter + shift - 26) : (char)(letter + shift) : letter;
        buffer[i] = letter;
      }
      return new string(buffer);
    }

    private static string DecryptServerIP(string ip)
    {
      long ipkey = 0x03081e11;
      long serverip = Convert.ToInt64(ip, 16);
      char[] decodedip = (serverip ^ ipkey).ToString("X8").ToCharArray();
      string realip = string.Empty;
      for (int i = 0; i < 4; i++)
      {
        realip += Convert.ToInt16(decodedip[i * 2].ToString() + decodedip[i * 2 + 1].ToString(), 16).ToString();
        if (i < 3)
          realip += ".";
      }

      return realip;
    }

    private static string DecryptServerPort(string port)
    {
      int portkey = 0x3630;
      int decodedport = Convert.ToInt32(port, 16) ^ portkey;

      return decodedport.ToString();
    }

    private static string ResolveServerName(string serverip)
    {
      string hostName = serverip;
      try
      {
        IPHostEntry IpEntry = Dns.GetHostEntry(serverip);
        hostName = IpEntry.HostName;
      }
      catch (Exception) { }

      return hostName;

    }

  }
  public class NetScalerDecryptedCookie
  {
    public NetScalerDecryptedCookie(string serviceGroupName, string serverIP, string serverPort, string serverName)
    {
      this.ServiceGroupName = serviceGroupName;
      this.ServerIP = serverIP;
      this.ServerPort = serverPort;
      this.ServerName = serverName;
    }
    public string ServiceGroupName { get; private set; }
    public string ServerIP { get; private set; }
    public string ServerPort { get; private set; }
    public string ServerName { get; private set; }
  }
}
