using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoloftAPI.Core.Model
{
    public class EventParticipant
    {
        [Key]

        public int ID { get; set; }

        [ForeignKey("Event")]
        public int EventID
        {
            get;
            set;
        }

        [ForeignKey("Participant")]
        public int ParticipantID
        {
            get;
            set;
        }

    }
}
