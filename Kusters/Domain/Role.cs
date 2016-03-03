using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Role
    {
        [Key]
        public int RoleId { get; set; }

       //public int PersonId { get; set; }
       public virtual List<Person> Persons { get; set; }

       //public int ChatId { get; set; }
       public virtual List<Chat> Chats { get; set; }

       //public virtual Person personId { get; set; }
       public char IsRole { get; set; }
        [MaxLength(32)]
        public string From { get; set; }
        [MaxLength(32)]
        public string Until { get; set; }
    }
}
