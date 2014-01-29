using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchinator.Domain
{
  public class EmailSettings
  {
    public static Lessthanchad.Email.EmailSettings GetEmailSettings()
    {
      return new Lessthanchad.Email.EmailSettings
      {
        SmtpServer = ConfigurationManager.AppSettings["SmtpHost"],
        UserName = ConfigurationManager.AppSettings["SendGridUserName"],
        Password = ConfigurationManager.AppSettings["SendGridPassword"],
        FromDisplayName = "Lunchinator",
        FromEmailAddress = "donotreply@lunchinator.com"

      };
    }
  }
}
