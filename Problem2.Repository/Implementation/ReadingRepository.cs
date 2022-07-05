using AutoMapper;
using Problem2.Database;
using Problem2.Database.Model;
using Problem2.Repository.Interface;
using Problem2.Utility;
using Problem2.Utility.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Problem2.Repository.Implementation
{
    public class ReadingRepository : IReadingRepository
    {
        private readonly AppDbContext context;

        public ReadingRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<SelectModel> BuildingSelectModels()
        {
            var selectModel = context.Building.ToList();
            return selectModel.OrderBy(x => x.Name).Select(x => new SelectModel()
            {
                Text = x.Name,
                Value = x.Id
            }).ToList();
        }
        public void GenerateSampleDataTest()
        {
            var truncateQuery = "truncate table Reading truncate table Building truncate table DataField truncate table [Object] ";
            context.Database.ExecuteSqlRaw(truncateQuery);
            DateTime dataGeneratedFrom = DateTime.Now;
            int totalDays = 730, totalBuildin = 100, dailyTimeStamp = 1440;
            for (int day = 1; day <= totalDays; day++)
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add(new DataColumn("BuildingId", typeof(byte)));
                tbl.Columns.Add(new DataColumn("ObjectId", typeof(byte)));
                tbl.Columns.Add(new DataColumn("DataFieldId", typeof(byte)));
                tbl.Columns.Add(new DataColumn("Value", typeof(decimal)));
                tbl.Columns.Add(new DataColumn("TimeStamp", typeof(DateTime)));
                for (byte b = 1; b <= totalBuildin; b++)
                {
                    if (day == 1)
                    {
                        Building building = new Building();
                        building.Id = b;
                        building.Name = "Building" + b;
                        context.Building.Add(building);
                        Objects objects = new Objects();
                        objects.Id = b;
                        objects.Name = "Object" + b;
                        context.Objects.Add(objects);

                        DataField dataField = new DataField();
                        dataField.Id = b;
                        dataField.Name = "DataField" + b;
                        context.DataField.Add(dataField);
                        context.SaveChanges();
                    }

                    for (int j = 1; j <= dailyTimeStamp; j++)
                    {
                        Random rnd = new Random();
                        DataRow dr = tbl.NewRow();
                        dr["BuildingId"] = b;
                        dr["ObjectId"] = b;
                        dr["DataFieldId"] = b;
                        dr["Value"] = rnd.NextDouble()*(1-50)+1;
                        dr["TimeStamp"] = dataGeneratedFrom.AddMinutes(j);
                        tbl.Rows.Add(dr);
                    }
                }
                string connection = "server=114.134.95.235,1434;database=Problem_2DB;User ID=sa;password=B@ngl@d3sh;";
                SqlConnection con = new SqlConnection(connection);
                //create object of SqlBulkCopy which help to insert  
                SqlBulkCopy objbulk = new SqlBulkCopy(con);

                //assign Destination table name  
                objbulk.DestinationTableName = "Reading";
                objbulk.ColumnMappings.Add("BuildingId", "BuildingId");
                objbulk.ColumnMappings.Add("ObjectId", "ObjectId");
                objbulk.ColumnMappings.Add("DataFieldId", "DataFieldId");
                objbulk.ColumnMappings.Add("Value", "Value");
                objbulk.ColumnMappings.Add("TimeStamp", "TimeStamp");

                con.Open();
                //insert bulk Records into DataBase.  
                objbulk.WriteToServer(tbl);
                con.Close();

            }

        }
        public List<SelectModel> GenerateTimeSeriesReport(Int16? buildingId, byte? objectId, byte? datafildId, DateTime startDate, DateTime endDate)
        {
            int topValue = 14400;
            var differece = endDate.Date - startDate.Date;
            if (differece.Days > 0)
            {
                topValue = topValue * (differece.Days + 1);
            }

            var query = "select top " + topValue + "  * from Reading where BuildingId=" + buildingId + " and ObjectId=" + objectId + " and DataFieldId=" + datafildId + " and convert(date,TimeStamp) between '" + startDate + "' and '" + endDate + "'";
            var data = context.Reading.FromSqlRaw(query);
            List<SelectModel> models = new List<SelectModel>();
            //StringBuilder sb = new StringBuilder("{'report':[");
            foreach (var item in data)
            {
                models.Add(new SelectModel { Text = item.TimeStamp, Value = item.Value });
                //sb.Append("[" + (long)(item.TimeStamp - new DateTime(1970, 1, 1)).TotalMilliseconds + "," + item.Value + "],");
            }
            //sb.Append("]}");

            //var jsonData = JObject.Parse(sb.ToString());

            return models;
        }

    }
}
