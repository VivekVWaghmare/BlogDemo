using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDemo.Models
{
    //[DynamoDBTable(tableName:"post")]
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime PostDateTime { get; set; }
        public string Content { get; set; }
    }
}
