using BlogDemo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDemo.Strategies
{
    public class IPBaseAuthorizer : IAuthorizer
    {
        private readonly IHttpContextAccessor _Accessor;
        private readonly IConfiguration _Configuration;
        public IPBaseAuthorizer(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _Accessor = accessor;
            _Configuration = configuration;
        }

        public bool IsAuthorize()
        {
            var IpV4 = _Accessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var validIp = _Configuration.GetSection("Security").GetValue<string>("ValidIp");
            return string.Compare(IpV4, validIp) == 0;
        }
    }
}
