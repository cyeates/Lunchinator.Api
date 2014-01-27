using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchinator.Data.Entities
{
    public class Rating
    {
        [Key, Column(Order=0)]
        public int UserId { get; set; }
        [Key, Column(Order=1)]
        public string BusinessId { get; set; }
        public double UserRating { get; set; }
    }
}
