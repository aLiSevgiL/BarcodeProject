using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BarcodManager : IBarcodService
    {
        IProductBarcodDal _barcodDal;

        public BarcodManager(IProductBarcodDal barcodDal)
        {
            _barcodDal = barcodDal;
        }


        public IResult AddShipmentDocumentBarcod(ProductBarcod productbarcod)
        {

            if (productbarcod.BarcodStr.Length > 5)
            {
                //_barcodDal.Add(productbarcod);

                _barcodDal.CallPARTISTOKBARKODILESEVKETProcedure(productbarcod.BarcodStr);
                return new Result(true, "barkodTarandi");
                
            }
            else
            {
                return new ErrorResult("barkod düzgün degil");
            }

        }

        public string CheckStatusByBarcode(string barcode)
        {

            var barcodItem = (_barcodDal.Get(p => p.BarcodStr == barcode));

            string status = barcodItem != null ? "Barkod Veritabanında Bulundu" : "Barkod Bulunamadı";

            return status;


        }

        public IDataResult<List<ProductBarcod>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
