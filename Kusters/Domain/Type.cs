using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Type
    {
        [Key]
        public int TypeId { get; set; }

       public int PersonId { get; set; }
       public virtual List<Person> Persons { get; set; }

       public int ChatId { get; set; }
       public virtual List<Chat> Chats { get; set; }

       //public virtual Person personId { get; set; }
       public char IsType { get; set; }
        [MaxLength(32)]
        public string From { get; set; }
        [MaxLength(32)]
        public string Until { get; set; }
    }
}
