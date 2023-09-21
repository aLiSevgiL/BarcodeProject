using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfProductBarcodDal : EfEntityRepositoryBase<ProductBarcod, FirebirdContext>, IProductBarcodDal
    {
        public void CallPARTISTOKBARKODILESEVKETProcedure(string barcode)
        {
            using (var context = new FirebirdContext())
            {
                var ABOYAIRSALIYEID = 207;
                var AFIRMAID = "0056";
                var ABARKODID = barcode; // Gelen barkod değeri
                var AKULLANICIID = 1;

                context.Database.ExecuteSqlRaw("EXECUTE PROCEDURE PARTISTOKBARKODILESEVKET {0}, {1}, {2}, {3}",
                    ABOYAIRSALIYEID, AFIRMAID, ABARKODID, AKULLANICIID);
            }
        }
    }
}
