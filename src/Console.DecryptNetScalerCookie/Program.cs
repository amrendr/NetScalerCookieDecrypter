using System;
using System.Text;
using NetScalerCookieDecrypter;

namespace Console.DecryptNetScalerCookie
{
  class Program
  {
    static void Main(string[] args)
    {
      string cookie = "NSC_dmpve4.tvnupubmtztufnt.dpn_443=ffffffffaf1f124645525d5f4f58455e445a4a423660";
      cookie = "NSC_qpsubm3.tvnupubmtztufnt.dpn_443=ffffffffaf1f135e45525d5f4f58455e445a4a42378b";
      System.Console.WriteLine(FormatCookie(cookie, false));
      
      System.Console.ReadLine();
    }

    private static string FormatCookie(string cookie, bool bResolveServerName)
    {
      NetScalerDecryptedCookie decryptedCookie = DecryptNetscalerCookie.DecryptCookie(cookie, bResolveServerName);

      if (decryptedCookie == null)
        return "Could not succesfully parse the cookie.";

      StringBuilder stringBuilder = new StringBuilder();
      if (!string.IsNullOrEmpty(decryptedCookie.ServiceGroupName))
        stringBuilder.AppendLine(String.Format("Service Group Name{0,2} {1}", ":", decryptedCookie.ServiceGroupName));

      if (!string.IsNullOrEmpty(decryptedCookie.ServerIP))
        stringBuilder.AppendLine(String.Format("Server IP{0,11} {1}", ":", decryptedCookie.ServerIP));

      if (!string.IsNullOrEmpty(decryptedCookie.ServerPort))
        stringBuilder.AppendLine(String.Format("Server Port{0,9} {1}", ":", decryptedCookie.ServerPort));

      if (!string.IsNullOrEmpty(decryptedCookie.ServerName))
        stringBuilder.AppendLine(String.Format("Server Name{0,9} {1}", ":", decryptedCookie.ServerName));

      return stringBuilder.ToString();
    }
  }
}
