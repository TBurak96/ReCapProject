﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Color entity)
        {
            throw new NotImplementedException();
        }

        public Color Get(Func<Color, bool> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll(Func<Color, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetCarsByBrandId(Func<Color, bool> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetCarsByColorId(Func<Color, bool> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
