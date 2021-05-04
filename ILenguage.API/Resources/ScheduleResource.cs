namespace ILenguage.API.Resources
{
    public class ScheduleResource
    {


        public int Id { get; set; }

        public string startedAt { get; set; }
        public string finishedAt { get; set; }
        public bool state { get; set; }



        public UserResource User { get; set; }

    }
}
