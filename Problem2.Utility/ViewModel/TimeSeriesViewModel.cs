using Problem2.Utility.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.Utility.ViewModel
{
    public class TimeSeriesViewModel
    {       
        public List<SelectModel> ObjectsSelectList { get; set; }
        public List<SelectModel> BuildingSelectList { get; set; }
        public List<SelectModel> DataFieldSelectList { get; set; }
   
    }
}
