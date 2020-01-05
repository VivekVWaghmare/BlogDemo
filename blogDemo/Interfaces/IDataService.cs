using BlogDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDemo.Interfaces
{
    public interface IDataService
    {
        Task Create(Post model);
        Task<List<Post>> GetAll();
    }
}
