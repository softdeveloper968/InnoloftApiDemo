using System.ComponentModel.DataAnnotations;

namespace InnoloftAPI.Core.Model
{
    public class Event
    {
        [Key]
        public int ID { get; set; }
        public int OwnerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime UpdateEventDate { get; set; }
        public DateTime CreateEventDate { get; set; }
        public string Timezone { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }


    }
}

