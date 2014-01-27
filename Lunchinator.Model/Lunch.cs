using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchinator.Data.Entities
{
    public class Lunch
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid LunchId { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Users invited to this event.
        /// </summary>
         public virtual List<User> Users { get; set; }
        
        /// <summary>
        /// Businesses that potentionally will be recommended.  Businesses that each user will rate will be drawn from this pool.
        /// </summary>
        public virtual List<Business> Businesses { get; set; }

        public Lunch()
        {
            LunchId = Guid.NewGuid();
            Users = new List<User>();
            Businesses = new List<Business>();
        }

        
    }
}
