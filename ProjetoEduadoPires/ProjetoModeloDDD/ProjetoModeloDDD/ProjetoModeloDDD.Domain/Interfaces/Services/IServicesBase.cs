using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
  public   interface IServicesBase<TEentity>where TEentity :class
    {

        void Add(TEentity obj);

        TEentity GetById(int id);

        IEnumerable<TEentity> GetAll();

        void Update(TEentity obj);
        void Remove(TEentity obj);
        void Dispose();


    }
}
