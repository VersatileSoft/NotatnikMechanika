using System;
using System.Collections.Generic;
using System.Linq;

namespace NotatnikMechanika.Model.Dao
{
    public class GoodsDao
    {
        public void AddGood(Good good)
        {
            using (var db = new MainEntities())
            {
                good.Id = db.Goods.Count();
                db.Goods.Add(good);
                db.SaveChangesAsync();
                db.Dispose();
            }
        }

        public void UpdateGood(Good good)
        {
            throw (new NotImplementedException());
        }

        public void DeleteGood(Good good)
        {
            throw (new NotImplementedException());
        }

        public List<Good> GetGoods()
        {
            List<Good> goods = new List<Good>();

            using (var db = new MainEntities())
            {

                goods = (from st in db.Goods select st).ToList();
            }

            return goods;
        }
    }
}