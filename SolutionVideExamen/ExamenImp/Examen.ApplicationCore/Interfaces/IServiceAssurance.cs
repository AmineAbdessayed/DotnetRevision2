using Examen.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Interfaces
{
    internal interface IServiceAssurance: IService<Assurance>
    {

        double AssurancePourcantage(TypeAssurance type);
    }
}
