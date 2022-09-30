using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vosplzen.sem1h4.Services.IServices;

namespace vosplzen.sem1h4.Services
{

    public class UserService:IUserService
    {
        private IHttpContextAccessor _httpcontext;

        public UserService(IHttpContextAccessor httpcontext)
        {
            _httpcontext = httpcontext;
        }

        public string GetCurrentUsername()
        {
            var result = _httpcontext.HttpContext.User?.Identity?.Name;
            return result;
        }
    }
}
