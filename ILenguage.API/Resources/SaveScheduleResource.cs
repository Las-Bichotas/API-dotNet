﻿using System.ComponentModel.DataAnnotations;

namespace ILenguage.API.Resources
{
    public class SaveScheduleResource
    {



        public string startedAt { get; set; }

        public string finishedAt { get; set; }

        public bool state { get; set; }

        public int UserId { get; set; }




    }
}
