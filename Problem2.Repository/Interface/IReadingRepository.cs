using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem2.Utility;
using Problem2.Utility.Model;

namespace Problem2.Repository.Interface
{
    public interface IReadingRepository
    {
        List<SelectModel> BuildingSelectModels();
        void GenerateSampleDataTest();
        List<SelectModel> GenerateTimeSeriesReport(Int16? buildingId, byte? objectId, byte? datafildId, DateTime startDate, DateTime endDate);
    }
}
