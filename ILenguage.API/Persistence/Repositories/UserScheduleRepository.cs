using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{
    public class UserScheduleRepository : BaseRepository, IUserScheduleRepository
    {
        public UserScheduleRepository(AppDbContext context) : base(context)
        {
        }

        

       
        
    }
}