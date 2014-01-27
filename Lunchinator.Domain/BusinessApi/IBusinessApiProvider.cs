using Lunchinator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchinator.Domain.BusinessApi
{
    public interface IBusinessApiProvider
    {
        IEnumerable<Business> GetBusinessesForEvent(SearchParameters search);
    }
}
