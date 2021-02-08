using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colordal;
        public ColorManager(IColorDal icolorDal)
        {
            _colordal = icolorDal;
        }

        public void Add(Color color)
        {
            _colordal.Add(color);
        }
        public void Update(Color color)
        {
            _colordal.Update(color);
        }


        public void Delete(Color color)
        {
            _colordal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colordal.GetAll();

        }

        public Color GetById(int id)
        {
            return _colordal.Get(c => c.Id == id);
        }

    }
}
