using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWorf
    {
        IPaisInterface Paises {get; set;}
/*         TipoPersona TipoPersonas {get; set;}
        IRegion Regiones {get; set;} */
        Task<int> SaveAsync {get; set;}

    
    }
}