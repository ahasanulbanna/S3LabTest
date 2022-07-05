using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.Utility.Model
{
    [Keyless]
    public class ReadingModel
    {
        
        public Int16 BuildingId { get; set; }

        public byte ObjectId { get; set; }

        public byte DataFieldId { get; set; }

     
        public decimal Value { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime TimeStamp { get; set; }

      
    }
}
