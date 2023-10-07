using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBarcodService
    {
      
        string CheckStatusByBarcode(string barcode);
        IResult AddShipmentDocumentBarcod(ProductBarcod productbarcod);
        IDataResult<List<ProductBarcod>> GetAll();
    }
}
