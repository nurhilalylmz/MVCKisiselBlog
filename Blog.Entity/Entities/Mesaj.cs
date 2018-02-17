using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class Mesaj
    {
        public int MailId { get; set; }
        public string MesajKonu { get; set; }
        public string MesajMail { get; set; }
        public string MesajIcerik { get; set; }

    }
}
