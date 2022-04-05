using EntitiesLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IEntityService<T> where T :  BaseModel
    {
        void Add(T model);
        List<T> GetAll();
        void Update(T model);
        void Delete(T model);
    }
}
