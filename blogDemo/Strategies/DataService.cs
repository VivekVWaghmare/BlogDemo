using Amazon.DynamoDBv2.DataModel;
using BlogDemo.Interfaces;
using BlogDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDemo.Strategies
{
    public class DataService : IDataService
    {
        private readonly IDynamoDBContext _Context;

        public DataService( IDynamoDBContext context)
        {
            _Context = context;
        }
        public async Task Create(Post model)
        {
            await _Context.SaveAsync<Post>(model);
        }

        public async Task<List<Post>> GetAll()
        {
            return await _Context.ScanAsync<Post>(new List<ScanCondition>()).GetRemainingAsync();
        }
    }
}
