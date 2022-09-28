using EntityFrameworkProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProjectLogic
{
    interface ICRUDLogic<T>
    {
        List<T> GetAll();
        void Update(T campo);
        void Delete(int id);
        void Add(T campo);
    }
}
