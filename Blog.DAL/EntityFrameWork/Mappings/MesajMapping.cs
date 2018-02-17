using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.EntityFrameWork.Mappings
{
    public class MesajMapping : EntityTypeConfiguration<Mesaj>
    {
        public MesajMapping()
        {
            this.HasKey<int>(x => x.MailId);

        }
    }
}