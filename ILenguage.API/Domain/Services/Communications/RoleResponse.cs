using ILanguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Services.Communications;

namespace ILanguage.API.Domain.Services.Communication
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
