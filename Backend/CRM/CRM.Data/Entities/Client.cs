using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
       
        public string Name { get; set; }
       
        public string Email { get; set; }
      
        public string Phone { get; set; }

        // FK → Property
        public int? PropertyId { get; set; }
        public Property Property { get; set; }
       
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
