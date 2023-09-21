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

        public IDataResult<ProductBarcod> CheckStatusByBarcode(string barcode)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductBarcod>> GetAll()
        {
           return new SuccessDataResult<List<ProductBarcod>>(_barcodDal.GetAll());
        }
    }
}
