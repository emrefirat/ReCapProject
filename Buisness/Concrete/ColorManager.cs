using Buisness.Abstract;
using Buisness.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Color color)
        {
            _colordal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }
        public IResult Update(Color color)
        {
            _colordal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);

        }


        public IResult Delete(Color color)
        {
            _colordal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colordal.GetAll(),Messages.AllColorListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colordal.Get(c => c.Id == id),Messages.ColorListedById);
        }

    }
}
