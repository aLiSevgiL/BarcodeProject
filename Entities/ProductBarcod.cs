using Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class ProductBarcod:IEntity
    {
        [Key]
        public string BarcodStr { get; set; }

    }
}
