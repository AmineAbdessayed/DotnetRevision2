using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure.Configurations
{
    internal class ExpertiseConfig : IEntityTypeConfiguration<Expertise>
    {

        public void Configure(EntityTypeBuilder<Expertise> builder)
        {
            builder.HasOne(t => t.Expert).WithMany(p => p.Expertises).HasForeignKey(t => t.ExpertFk);
            builder.HasOne(t => t.Sinistre).WithMany(p => p.Expertises).HasForeignKey(t => t.SinistreFk);

            builder.HasKey(r => new
            {
                r.ExpertFk,
                r.SinistreFk,
                r.DateExpertise


            });
        }
    }
}
