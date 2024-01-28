using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncomentManager : IAnnouncomentService
    {
        private readonly IAnnouncomentDal _announcomentDal;

        public AnnouncomentManager(IAnnouncomentDal announcomentDal)
        {
            _announcomentDal = announcomentDal;
        }

        public void TAdd(Announcoment t)
        {
            _announcomentDal.Insert(t);
        }

        public void TDelete(Announcoment t)
        {
            _announcomentDal.Delete(t);
        }

        public Announcoment TGetByID(int id)
        {
            return _announcomentDal.GetByID(id);
        }

        public List<Announcoment> TGetList()
        {
            return _announcomentDal.GetList();
        }

        public void TUpdate(Announcoment t)
        {
            _announcomentDal.Update(t);
        }
    }
}
