using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewingsApp.Models.Database
{
    public class Agent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }

        public bool IsFreeForViewing(DateTime viewingStart, DateTime viewingEnd)
        {
            return !IsBeforeWorkStarts(viewingStart) && !IsAfterWorkEnds(viewingEnd);
        }

        private bool IsBeforeWorkStarts(DateTime dateTime)
        {
            return dateTime.Hour < StartTime;
        }

        private bool IsAfterWorkEnds(DateTime dateTime)
        {
            return dateTime.Hour > EndTime
                   || dateTime.Hour == EndTime && dateTime.Minute > 0;
        }
    }
}