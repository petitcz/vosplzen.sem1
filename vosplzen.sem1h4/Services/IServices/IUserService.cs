using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vosplzen.sem1h4.Services.IServices
{
    

    public interface IUserService
    {
        string GetCurrentUsername();
    }
}
