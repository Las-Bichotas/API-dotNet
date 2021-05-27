using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Services.Communications;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services.Communication
{
    public class RoleResponse : BaseResponse<Role>
    {
        public RoleResponse(Role resource) : base(resource)
        {
        }
        public RoleResponse(string message) : base(message)
        {
        }
    }
}
