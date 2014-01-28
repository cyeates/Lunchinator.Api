using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lunchinator.Api.Models
{
  public class InviteUserModel
  {
    public Guid LunchId { get; set; }
    public string EmailAddress { get; set; }
  }
}