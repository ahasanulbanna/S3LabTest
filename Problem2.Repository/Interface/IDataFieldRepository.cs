using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem2.Utility;
using Problem2.Utility.Model;

namespace Problem2.Repository.Interface
{
    public interface IDataFieldRepository
    {
        List<SelectModel> DataFieldSelectModels();
    }
}
