using Microsoft.AspNetCore.Mvc;
using Problem2.Repository.Interface;
using Problem2.Utility.ViewModel;

namespace Problem2.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TimeSeriesController : ControllerBase
    {

        private readonly IReadingRepository readingRepository;
        private readonly IBuildingRepository buildingRepository;
        private readonly IDataFieldRepository dataFieldRepository;
        private readonly IObjectsRepository objectsRepository;

        public TimeSeriesController(IReadingRepository readingRepository, IObjectsRepository objectsRepository, IDataFieldRepository dataFieldRepository, IBuildingRepository buildingRepository)
        {
            this.readingRepository = readingRepository;
            this.buildingRepository = buildingRepository;
            this.dataFieldRepository = dataFieldRepository;
            this.objectsRepository = objectsRepository;
        }


        [HttpGet("sample-data-generate")]
        public async Task<IActionResult> GenerateChartSampleData()
        {
            readingRepository.GenerateSampleDataTest();

            return Ok(new { Message = "Saved Successfully." });
        }

        [HttpGet("get-time-series")]
        public async Task<IActionResult> GetTimeSeriesChart()
        {
            var viewModel = new TimeSeriesViewModel();

            viewModel.BuildingSelectList = buildingRepository.BuildingSelectModels();
            viewModel.DataFieldSelectList = dataFieldRepository.DataFieldSelectModels();
            viewModel.ObjectsSelectList = objectsRepository.ObjectsSelectModels();

            return Ok(viewModel);
        }


        [HttpGet("get-time-series-chart-data")]
        public async Task<IActionResult> GetTimeSeriesData(byte? buildingId, byte? objectId, byte? datafildId, string timeStamp)
        {
            DateTime startDate = DateTime.Now.Date;
            DateTime endDate = DateTime.Now.Date;
            if (timeStamp != null)
            {
                var st = timeStamp.Split("to");
                //st[0] = st[0].Substring(4, 11);
                //st[1] = st[1].Substring(4, 11);
                startDate = Convert.ToDateTime(st[0]);
                endDate = Convert.ToDateTime(st[1]);
            }
            if (buildingId == 0 || buildingId == null)
            {
                buildingId = 1;
            }
            if (objectId == 0 || objectId == null)
            {
                objectId = 1;
            }
            if (datafildId == 0 || datafildId == null)
            {
                datafildId = 1;
            }

            var data = readingRepository.GenerateTimeSeriesReport(buildingId, objectId, datafildId, startDate, endDate);

            return Ok(data.ToList());
        }


    }
}
