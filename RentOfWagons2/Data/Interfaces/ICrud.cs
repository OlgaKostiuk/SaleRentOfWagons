using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    interface ICrud<TModel>
    {
        TModel Create(TModel model);
        TModel Update(TModel model);
        void Delete(int id);
        TModel GetById(int id);
    }
}
