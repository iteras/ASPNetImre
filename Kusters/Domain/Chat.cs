﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Chat
    {
        [Key]
        public int ChatId { get; set; }

       public int TypeId { get; set; }
       public virtual Type Type { get; set; }

       public int PersonId { get; set; }
       public virtual Person Person { get; set; }

       public int PersonInChatId { get; set; }
       public virtual List<PersonInChat> PersonsInChat { get; set; }

       public int PretensionId { get; set; }
       public virtual Pretension Pretension { get; set; }

        [MaxLength(255)]
       public string Message { get; set; }

        [MaxLength(32)]
       public string DateTime { get; set; }


    }
}
