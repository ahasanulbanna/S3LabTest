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

namespace Problem2.Repository.Implementation
{
    public class ObjectsRepository : IObjectsRepository
    {
       private readonly AppDbContext context;

        public ObjectsRepository(AppDbContext context)
        {
            this.context = context;
        }


        public List<SelectModel> ObjectsSelectModels()
        {
            var selectModel = context.Objects.ToList();
            return selectModel.OrderBy(x => x.Name).Select(x => new SelectModel()
            {
                Text = x.Name,
                Value = x.Id
            }).ToList();

        }

    }
}
