using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Entities
{
    public class Property
    {
        public int Id { get; set; }
       
        public string Title { get; set; }
        
        public string Address { get; set; }
       
        public decimal Price { get; set; }

        // FK → User
        
        public Guid UserId { get; set; }
        public User User { get; set; }


    }
}
