using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Expertise
    {
        [DataType(DataType.Date, ErrorMessage = "error must be date")]
        public DateTime DateExpertise { get; set; }

        [DataType(DataType.MultilineText)]
        public string AvisTechnique { get; set; }

        public double Duree { get; set; } // Change the data type to double

        public virtual Expert Expert { get; set; }
        public virtual Sinistre Sinistre { get; set; }

        public int ExpertFk { get; set; }
        public int SinistreFk { get; set; }
    }
}
