using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    internal class ServiceAssurance : Service<Assurance>, IServiceAssurance
    {


        public ServiceAssurance(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
           

        }

        
        public double AssurancePourcantage(TypeAssurance type)
        {

            return 211;

        }
        
    }
}
