﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Models
{
    public class SessionDetail
    {
        public int Id { get; set; }

        public string State { get; set; }

        public int SessionId { get; set; }
        public Session Session { set; get; }
    }
}