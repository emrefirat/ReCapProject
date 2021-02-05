using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //InMemory formatta GetById, GetAll, +Add, +Update, +Delete oprasyonlarını yazınız.
    public interface ICarDal:IEntityRepository<Car>
    {
    }
}
