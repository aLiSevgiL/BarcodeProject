using Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class ProductBarcod:IEntity
    {
        [Key]
        [Column("BARKODSTR")]
        public string BarcodStr { get; set; }

    }
}
