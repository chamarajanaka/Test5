using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassLibrary.Interfaces
{
    public interface iCURD<T>
    {
         T Read();

         List<T> ReadAll();

         void Create(List<T> model);

         void Update(T model);

    }
}
