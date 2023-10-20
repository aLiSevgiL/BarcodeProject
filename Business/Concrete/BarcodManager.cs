using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using Newtonsoft.Json;
using Business.Infrastructure.Cache.Redis;

namespace Business.Concrete
{
    public class BarcodManager : IBarcodService
    {
        IProductBarcodDal _barcodDal;
        private readonly IRedisService _redisService;
        public BarcodManager(IProductBarcodDal barcodDal,IRedisService redisManager)
        {
            _barcodDal = barcodDal;
            _redisService = redisManager;
            
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
            string cacheKey = $"barcode_{barcode}"; 
           
            var cache= _redisService.GetKey(cacheKey);

            if (!string.IsNullOrEmpty(cache)) return cache;



            var barcodeEntity = _barcodDal.Get(x => x.BarcodStr == barcode);
            _redisService.SetKey(cacheKey, barcodeEntity.BarcodStr,30);
            return barcodeEntity.BarcodStr;

        }


        public bool CheckIfKeyExists(string key)
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6380");
            var db = redis.GetDatabase();

            return db.KeyExists(key);
        }

        public IDataResult<List<ProductBarcod>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
