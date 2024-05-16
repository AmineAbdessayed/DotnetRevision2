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
    internal class AssuranceConfig : IEntityTypeConfiguration<Assurance>
    {

        public void Configure(EntityTypeBuilder<Assurance> builder)
        {

            builder.HasMany(t => t.Sinistres).WithOne(p => p.assurance).HasForeignKey(t => t.AssuranceFk);


        }
    }
}
